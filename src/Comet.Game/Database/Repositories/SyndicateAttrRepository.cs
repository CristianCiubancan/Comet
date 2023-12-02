using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class SyndicateAttrRepository
    {
        public static async Task<List<DbSyndicateAttr>> GetAsync(uint idSyn)
        {
            await using var db = new ServerDbContext();
            return db.SyndicatesAttr.Where(x => x.SynId == idSyn).ToList();
        }
    }
}
