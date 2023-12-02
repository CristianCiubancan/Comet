using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comet.Game.Database.Repositories
{
    public static class JiangHuAttribRandRepository
    {
        public static async Task<List<DbJiangHuAttribRand>> GetAsync()
        {
            await using var serverDbContext = new ServerDbContext();
            return await serverDbContext.JiangHuAttribRands.ToListAsync();
        }
    }
}
