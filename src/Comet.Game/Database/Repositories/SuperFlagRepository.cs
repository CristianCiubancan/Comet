using Comet.Database.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comet.Game.Database.Repositories
{
    public static class SuperFlagRepository
    {
        public static async Task<List<DbSuperFlag>> GetAsync(uint itemId)
        {
            await using ServerDbContext serverDbContext = new();
            return serverDbContext.SuperFlags.Where(x => x.ItemId == itemId).Take(10).ToList();
        }
    }
}
