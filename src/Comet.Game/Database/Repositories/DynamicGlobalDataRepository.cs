using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class DynamicGlobalDataRepository
    {
        public static async Task<List<DbDynaGlobalData>> GetAsync()
        {
            await using var ctx = new ServerDbContext();
            return await ctx.DynaGlobalDatas.ToListAsync();
        }

        public static async Task<List<DbDynaGlobalData>> GetAsync(params uint[] ids)
        {
            await using var ctx = new ServerDbContext();
            return await ctx.DynaGlobalDatas
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();
        }
    }
}
