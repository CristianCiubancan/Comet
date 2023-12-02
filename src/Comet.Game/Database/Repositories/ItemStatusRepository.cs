using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class ItemStatusRepository
    {
        public static async Task<List<DbItemStatus>> GetAsync(uint idItem)
        {
            await using ServerDbContext serverDbContext = new();
            return await serverDbContext.ItemStatus.Where(x => x.ItemId == idItem).ToListAsync();
        }
    }
}
