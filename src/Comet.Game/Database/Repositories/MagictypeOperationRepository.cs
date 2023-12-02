using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comet.Game.Database.Repositories
{
    public static class MagictypeOperationRepository
    {
        public static async Task<List<DbMagictypeOp>> GetAsync()
        {
            await using var db = new ServerDbContext();
            return await db.MagictypeOperations.ToListAsync();
        }
    }
}
