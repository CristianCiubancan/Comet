﻿using Comet.Game.Database;
using Comet.Shared;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Linq;

namespace Comet.Game.Services.Processors
{
    public class ServerProcessor : BackgroundService
    {
        public const int NO_MAP_GROUP = 0;
        public const int PVP_MAP_GROUP = 1;
        public const int NORMAL_MAP_GROUP = 2;

        private static readonly ILogger logger = LogFactory.CreateLogger<ServerProcessor>();

        protected readonly Task[] backgroundTasks;
        protected readonly Channel<Func<Task>>[] channels;
        protected readonly Partition[] partitions;
        protected CancellationToken cancelReads;
        protected CancellationToken cancelWrites;

        public int Count { get; init; }

        public ServerProcessor(CancellationToken cancellationToken)
        {
            // Count = Math.Min(ServerConfiguration.Configuration.Realm.Processors, Environment.ProcessorCount) + NORMAL_MAP_GROUP;

            backgroundTasks = new Task[Count];
            channels = new Channel<Func<Task>>[Count];
            partitions = new Partition[Count];

            cancelReads = cancellationToken;
            cancelWrites = cancellationToken;
        }

        protected override Task ExecuteAsync(CancellationToken token)
        {
            for (var i = 0; i < Count; i++)
            {
                partitions[i] = new Partition { ID = (uint)i, Weight = 0 };
                channels[i] = Channel.CreateUnbounded<Func<Task>>();
                backgroundTasks[i] = DequeueAsync(i, channels[i]);
            }

            return Task.WhenAll(backgroundTasks);
        }

        public void Queue(int partition, Func<Task> task)
        {
            cancelWrites.ThrowIfCancellationRequested();
            channels[partition].Writer.TryWrite(task);
        }

        protected virtual async Task DequeueAsync(int partition, Channel<Func<Task>> channel)
        {
            while (!cancelReads.IsCancellationRequested)
            {
                Func<Task> action = await channel.Reader.ReadAsync(cancelReads);
                if (action != null)
                {
                    try
                    {
                        await action.Invoke().ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        logger.LogCritical(ex, "Exception thrown when dequeuing action on partition [{Partition}]\n{Message}", partition, ex.Message);
                    }
                }
            }
        }

        /// <summary>
        ///     Selects a partition for the client actor based on partition weight. The
        ///     partition with the least popluation will be chosen first. After selecting a
        ///     partition, that partition's weight will be increased by one.
        /// </summary>
        public uint SelectPartition()
        {
            uint partition = partitions.Where(x => x.ID >= NORMAL_MAP_GROUP).Aggregate((aggr, next) =>
                                                                            next.Weight.CompareTo(aggr.Weight) < 0
                                                                                ? next
                                                                                : aggr).ID;
            Interlocked.Increment(ref partitions[partition].Weight);
            return partition;
        }

        public void SelectPartition(uint partition)
        {
            Interlocked.Increment(ref partitions[partition].Weight);
        }

        /// <summary>
        ///     Deslects a partition after the client actor disconnects.
        /// </summary>
        /// <param name="partition">The partition id to reduce the weight of</param>
        public void DeselectPartition(uint partition)
        {
            Interlocked.Decrement(ref partitions[partition].Weight);
        }

        public async Task CompletionAsync()
        {
            foreach (Channel<Func<Task>> channel in channels)
            {
                if (channel.Reader.Count > 0)
                {
                    await channel.Reader.Completion;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"Server Processor running with {Count} tasks [Tick Frequency: {Stopwatch.Frequency}]");
            for (int i = 0; i < Count; i++)
            {
                stringBuilder.AppendLine($"Channel {i:00}, Weight: {partitions[i].Weight}");
            }
            return stringBuilder.ToString();
        }

        protected class Partition
        {
            public uint ID;
            public int Weight;
        }
    }
}