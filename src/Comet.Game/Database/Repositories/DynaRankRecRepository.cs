using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class DynaRankRecRepository
    {
        public static async Task<List<DbDynaRankRec>> GetAsync(uint rankType)
        {
            await using var ctx = new ServerDbContext();
            return await ctx.DynaRankRecs.Where(x => x.RankType == rankType).ToListAsync();
        }
    }
}
