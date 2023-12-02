using Comet.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class MonsterypeRepository
    {
        public static async Task<List<DbMonstertype>> GetAsync()
        {
            await using var context = new ServerDbContext();
            return context.Monstertype.ToList();
        }
    }
}
