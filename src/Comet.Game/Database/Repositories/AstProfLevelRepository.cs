using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class AstProfLevelRepository
    {
        public static async Task<List<DbAstProfLevel>> GetAsync(uint idUser)
        {
            await using var ctx = new ServerDbContext();
            return await ctx.AstProfLevels.Where(x => x.UserIdentity == idUser).ToListAsync();
        }
    }
}
