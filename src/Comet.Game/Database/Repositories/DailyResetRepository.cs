using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class DailyResetRepository
    {
        public static async Task<DbDailyReset> GetLatestAsync()
        {
            await using var ctx = new ServerDbContext();
            return await ctx.DailyResets.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }
    }
}
