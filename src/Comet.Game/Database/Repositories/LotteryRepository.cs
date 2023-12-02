using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comet.Game.Database.Repositories
{
    public static class LotteryRepository
    {
        public static async Task<List<DbLottery>> GetAsync()
        {
            await using ServerDbContext ctx = new();
            return await ctx.Lottery.ToListAsync();
        }
    }
}
