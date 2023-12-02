using Comet.Database.Entities;
using System.Threading.Tasks;

namespace Comet.Game.Database.Repositories
{
    public static class VipMineTimeRepository
    {
        public static async Task<DbVipMineTime> GetAsync(uint idUser)
        {
            await using var ctx = new ServerDbContext();
            return await ctx.VipMineTime.FindAsync(idUser);
        }
    }
}
