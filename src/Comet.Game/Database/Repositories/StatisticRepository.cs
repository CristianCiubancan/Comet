using Comet.Database.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comet.Game.Database.Repositories
{
    public static class StatisticRepository
    {
        public static async Task<List<DbStatistic>> GetAsync(uint idUser)
        {
            await using var db = new ServerDbContext();
            return db.Statistics.Where(x => x.PlayerIdentity == idUser).ToList();
        }

        public static async Task<List<DbStatisticDaily>> GetDailyAsync(uint idUser)
        {
            await using var db = new ServerDbContext();
            return db.DailyStatistics.Where(x => x.PlayerId == idUser).ToList();
        }
    }
}
