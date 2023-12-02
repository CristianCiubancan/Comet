using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comet.Game.Database.Repositories
{
    public static class FateInitAttribRepository
    {
        public static async Task<IList<DbInitFateAttrib>> GetAsync()
        {
            await using var ctx = new ServerDbContext();
            return await ctx.InitFateAttribs.ToListAsync();
        }
    }
}
