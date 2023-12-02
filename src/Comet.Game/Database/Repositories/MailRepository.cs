using System.Collections.Generic;
using System.Threading.Tasks;
using Comet.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Comet.Game.Database.Repositories
{
    public static class MailRepository
    {
        public static async Task<List<DbMail>> GetAsync(uint idUser)
        {
            await using var serverDbContext = new ServerDbContext();
            return await serverDbContext.Mails.Where(x => x.ReceiverId == idUser).ToListAsync();
        }
    }
}
