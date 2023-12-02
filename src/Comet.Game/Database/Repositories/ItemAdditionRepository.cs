using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comet.Game.Database.Repositories
{
    public static class ItemAdditionRepository
    {
        public static async Task<List<DbItemAddition>> GetAsync()
        {
            await using var db = new ServerDbContext();
            return await db.ItemAdditions.ToListAsync();
        }
    }
}
