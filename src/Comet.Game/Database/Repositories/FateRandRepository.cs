using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comet.Game.Database.Repositories
{
    public static class FateRandRepository
    {
        public static async Task<IList<DbFateRand>> GetAsync()
        {
            await using var ctx = new ServerDbContext();
            return await ctx.FateRands.ToListAsync();
        }
    }
}
