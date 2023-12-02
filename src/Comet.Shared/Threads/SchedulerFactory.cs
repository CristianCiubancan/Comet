﻿using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using LogLevel = Quartz.Logging.LogLevel;

namespace Comet.Shared.Threads
{
    public sealed class SchedulerFactory
    {
        private readonly StdSchedulerFactory factory;
        private IScheduler scheduler;

        public SchedulerFactory()
        {
            LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());

            factory = new StdSchedulerFactory();
        }

        public async Task StartAsync()
        {
            scheduler = await factory.GetScheduler();
            await scheduler.Start();
        }

        public async Task StopAsync()
        {
            await scheduler.Shutdown();
        }

        public async Task ScheduleAsync<T>(string cron) where T : IJob
        {
            string name = typeof(T).Name;
            var key = new JobKey(name);
            IJobDetail job = JobBuilder.Create<T>()
                                       .WithIdentity(key)
                                       .Build();

            ITrigger trigger = TriggerBuilder.Create()
                                             .WithIdentity(name)
                                             .StartNow()
                                             .WithCronSchedule(cron)
                                             .Build();

            await scheduler.ScheduleJob(job, trigger);
        }

        private class ConsoleLogProvider : ILogProvider
        {
            private static readonly ILogger logger = LogFactory.CreateLogger<SchedulerFactory>();

            public Logger GetLogger(string name)
            {
                return (level, func, exception, parameters) =>
                {
                    const LogLevel minLevel = LogLevel.Info;

                    if (level >= minLevel && func != null)
                    {
                        switch (level)
                        {
                            case LogLevel.Debug:
                                {
                                    logger.LogDebug(func(), parameters);
                                    break;
                                }
                            case LogLevel.Info:
                                {
                                    logger.LogInformation(func(), parameters);
                                    break;
                                }
                            case LogLevel.Fatal:
                                {
                                    logger.LogCritical(func(), parameters);
                                    break;
                                }
                            case LogLevel.Trace:
                                {
                                    logger.LogTrace(func(), parameters);
                                    break;
                                }
                            case LogLevel.Warn:
                                {
                                    logger.LogWarning(func(), parameters);
                                    break;
                                }
                            case LogLevel.Error:
                                {
                                    logger.LogError(func(), parameters);
                                    break;
                                }
                        }
                    }
                    return true;
                };
            }

            public IDisposable OpenNestedContext(string message)
            {
                return new DisposableDummy();
                //throw new NotImplementedException();
            }

            public IDisposable OpenMappedContext(string key, object value, bool destructure = false)
            {
                //throw new NotImplementedException();
                return new DisposableDummy();
            }

            private class DisposableDummy : IDisposable
            {
                void IDisposable.Dispose()
                {
                }
            }
        }
    }
}
