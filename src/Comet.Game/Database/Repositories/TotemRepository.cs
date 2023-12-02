﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class TotemRepository
    {
        public static async Task<List<DbTotemAdd>> GetAsync(uint idSyndicate)
        {
            await using var ctx = new ServerDbContext();
            return await ctx.TotemAdds.Where(x => x.OwnerIdentity == idSyndicate).ToListAsync();
        }
    }
}
