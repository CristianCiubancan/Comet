using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comet.Game.Database.Repositories
{
    public static class GoldenLeagueRepository
    {
        public static async Task<DbGoldenLeagueData> GetAsync(uint idUser)
        {
            await using var ctx = new ServerDbContext();
            return await ctx.GoldenLeagueDatas.FirstOrDefaultAsync(x => x.UserId == idUser);
        }
    }
}
