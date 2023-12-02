using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comet.Game.Database.Repositories
{
    public static class AstProfPromoteConditionRepository
    {
        public static async Task<List<DbAstProfPromoteCondition>> GetAsync()
        {
            await using var ctx = new ServerDbContext();
            return await ctx.AstProfPromoteConditions.ToListAsync();
        }
    }
}
