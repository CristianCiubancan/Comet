using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class PkStatisticRepository
    {
        public static async Task<List<DbPkStatistic>> GetAsync(uint idUser)
        {
            await using var ctx = new ServerDbContext();
            return await ctx.PkStatistics
                .Where(x => x.KillerId == idUser)
                .ToListAsync();
        }
    }
}
