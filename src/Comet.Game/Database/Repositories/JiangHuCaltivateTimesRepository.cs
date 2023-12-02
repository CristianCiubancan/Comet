using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comet.Game.Database.Repositories
{
    public static class JiangHuCaltivateTimesRepository
    {
        public static async Task<DbJiangHuCaltivateTimes> GetAsync(uint idUser)
        {
            await using var serverDbContext = new ServerDbContext();
            return await serverDbContext.JiangHuCaltivateTimes.FirstOrDefaultAsync(x => x.PlayerId == idUser);
        }
    }
}
