using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comet.Game.Database.Repositories
{
    public static class JiangHuCaltivateConditionRepository
    {
        public static async Task<List<DbJiangHuCaltivateCondition>> GetAsync()
        {
            await using var serverDbContext = new ServerDbContext();
            return await serverDbContext.JiangHuCaltivateConditions.ToListAsync();
        }
    }
}
