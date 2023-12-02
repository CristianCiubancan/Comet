using Comet.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class TaskRepository
    {
        public static async Task<List<DbTask>> GetAsync()
        {
            await using var db = new ServerDbContext();
            return db.Tasks.ToList();
        }
    }
}
