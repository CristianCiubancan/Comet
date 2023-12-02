using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comet.Game.Database.Repositories
{
    public static class AstProfInaugurationConditionRepository
    {
        public static async Task<List<DbAstProfInaugurationCondition>> GetAsync()
        {
            await using var ctx = new ServerDbContext();
            return await ctx.AstProfInaugurationConditions.ToListAsync();
        }
    }
}
