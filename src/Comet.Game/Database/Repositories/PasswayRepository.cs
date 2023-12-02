using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class PasswayRepository
    {
        public static async Task<List<DbPassway>> GetAsync(uint idMap)
        {
            await using var context = new ServerDbContext();
            return await context.Passways.Where(x => x.MapId == idMap).ToListAsync();
        }
    }
}
