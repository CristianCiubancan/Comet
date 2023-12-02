using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comet.Game.Database.Repositories
{
    public static class PointAllotRepository
    {
        public static async Task<List<DbPointAllot>> GetAsync()
        {
            await using var db = new ServerDbContext();
            return await db.PointAllots.ToListAsync();
        }
    }
}
