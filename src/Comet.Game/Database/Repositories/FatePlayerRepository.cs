using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comet.Game.Database.Repositories
{
    public static class FatePlayerRepository
    {
        public static async Task<IList<DbFatePlayer>> GetAsync()
        {
            await using var ctx = new ServerDbContext();
            return await ctx.FatePlayers.ToListAsync();
        }

        public static async Task<DbFatePlayer> GetAsync(uint idUser)
        {
            await using var ctx = new ServerDbContext();
            return await ctx.FatePlayers.FirstOrDefaultAsync(x => x.PlayerId == idUser);
        }
    }
}
