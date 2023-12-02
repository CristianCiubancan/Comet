using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comet.Game.Database.Repositories
{
    public static class SupermanRepository
    {
        public static async Task<List<DbSuperman>> GetAsync()
        {
            await using ServerDbContext serverDbContext = new();
            return await serverDbContext.Superman.ToListAsync();
        }
    }
}
