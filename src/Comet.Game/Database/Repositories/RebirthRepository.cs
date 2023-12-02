using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comet.Game.Database.Repositories
{
    public static class RebirthRepository
    {
        public static async Task<List<DbRebirth>> GetAsync()
        {
            await using var db = new ServerDbContext();
            return await db.Rebirths.ToListAsync();
        }
    }
}
