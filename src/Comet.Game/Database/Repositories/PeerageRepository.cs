using Comet.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class PeerageRepository
    {
        public static async Task<List<DbDynaRankRec>> GetAsync()
        {
            await using var context = new ServerDbContext();
            return context.DynaRankRecs.Where(x => x.RankType == 3_000_003).ToList();
        }
    }
}
