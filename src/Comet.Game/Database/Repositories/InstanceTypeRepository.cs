using Comet.Database.Entities;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class InstanceTypeRepository
    {
        public static DbInstanceType Get(uint instanceType)
        {
            using var ctx = new ServerDbContext();
            return ctx.InstanceTypes
                //.Include(x => x.EnterCondition)
                .FirstOrDefault(x => x.Id == instanceType);
        }
    }
}
