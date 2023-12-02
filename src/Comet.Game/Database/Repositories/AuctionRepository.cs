using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class AuctionRepository
    {
        public static async Task<List<DbAuction>> GetAsync()
        {
            await using ServerDbContext context = new();
            return await context.Auctions.ToListAsync();
        }

        public static async Task<List<DbAuctionAskBuy>> GetAskBuyAsync(uint auctionId)
        {
            await using ServerDbContext context = new();
            return await context.AuctionAskBuys.Where(x => x.AuctionId == auctionId).ToListAsync();
        }
    }
}