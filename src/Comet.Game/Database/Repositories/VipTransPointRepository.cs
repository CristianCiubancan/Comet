using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comet.Game.Database.Repositories
{
    public static class VipTransPointRepository
    {
        public static async Task<DbVipTransPoint> GetAsync(uint id)
        {
            await using var ctx = new ServerDbContext();
            return await ctx.VipTransPoints.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
