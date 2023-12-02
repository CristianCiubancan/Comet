using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comet.Game.Database.Repositories
{
    public static class JiangHuQualityRandRepository
    {
        public static async Task<List<DbJiangHuQualityRand>> GetAsync()
        {
            await using var serverDbContext = new ServerDbContext();
            return await serverDbContext.JiangHuQualityRands.ToListAsync();
        }
    }
}
