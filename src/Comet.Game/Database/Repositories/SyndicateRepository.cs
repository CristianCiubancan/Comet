using Comet.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Comet.Shared;

namespace Comet.Game.Database.Repositories
{
    public static class SyndicateRepository
    {
        public static async Task<List<DbSyndicate>> GetAsync()
        {
            await using var db = new ServerDbContext();
            return db.Syndicates.ToList();
        }

        public static async Task<List<DbSynAdvertisingInfo>> GetAdvertiseAsync()
        {
            await using var db = new ServerDbContext();
            return db.SynAdvertisingInfos.Where(x => x.EndDate > UnixTimestamp.Now).ToList();
        }
    }
}
