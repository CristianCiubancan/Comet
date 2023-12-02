using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Comet.Game.Database.Repositories
{
    public static class ArenicRepository
    {
        public static async Task<List<DbArenic>> GetAsync(DateTime date, int type)
        {
            await using var ctx = new ServerDbContext();
            return await ctx.Arenics
                            .Where(x => x.Date == uint.Parse(date.Date.ToString("yyyyMMdd")) && x.Type == type)
                            .ToListAsync();
        }
    }
}
