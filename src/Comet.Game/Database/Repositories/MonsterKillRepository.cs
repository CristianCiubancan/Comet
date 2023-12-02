using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class MonsterKillRepository
    {
        public static async Task<List<DbMonsterKill>> GetAsync(uint idUser)
        {
            await using var ctx = new ServerDbContext();
            return await ctx.MonsterKills.Where(x => x.UserIdentity == idUser).ToListAsync();
        }
    }
}
