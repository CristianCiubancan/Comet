using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class StatusRepository
    {
        public static async Task<List<DbStatus>> GetAsync(uint idUser)
        {
            await using var db = new ServerDbContext();
            return await db.Status.Where(x => x.OwnerId == idUser).ToListAsync();
        }
    }
}
