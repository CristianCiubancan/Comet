﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class RegionRepository
    {
        public static async Task<List<DbRegion>> GetAsync(uint idMap)
        {
            await using var ctx = new ServerDbContext();
            return await ctx.Regions.Where(x => x.MapIdentity == idMap).ToListAsync();
        }
    }
}
