using Comet.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class NpcRepository
    {
        public static async Task<List<DbNpc>> GetAsync()
        {
            await using var context = new ServerDbContext();
            return context.Npcs.ToList();
        }
    }
}
