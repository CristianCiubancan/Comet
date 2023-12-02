using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class FateProtectRepository
    {
        public static async Task<IList<DbFateProtect>> GetAsync(uint idUser)
        {
            await using var ctx = new ServerDbContext();
            return await ctx.FateProtects.Where(x => x.PlayerId == idUser).ToListAsync();
        }
    }
}
