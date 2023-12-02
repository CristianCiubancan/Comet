using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class TutorRepository
    {
        public static async Task<DbTutor> GetAsync(uint idStudent)
        {
            await using var ctx = new ServerDbContext();
            return await ctx.Tutor
                            .FirstOrDefaultAsync(x => x.StudentId == idStudent);
        }

        public static async Task<List<DbTutor>> GetStudentsAsync(uint idTutor)
        {
            await using var ctx = new ServerDbContext();
            return await ctx.Tutor
                            .Where(x => x.GuideId == idTutor)
                            .ToListAsync();
        }
    }
}
