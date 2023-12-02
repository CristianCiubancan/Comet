using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class CompeteRankRepository
    {
        public static async Task<List<DbSynCompeteRank>> GetSynCompeteRankAsync()
        {
            await using ServerDbContext serverDbContext = new();
            return await serverDbContext.SynCompeteRanks.OrderBy(x => x.Rank).ToListAsync();
        }
    }
}