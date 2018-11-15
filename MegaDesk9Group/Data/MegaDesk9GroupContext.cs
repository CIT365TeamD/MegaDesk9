using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MegaDesk9Group.Models
{
    public class MegaDesk9GroupContext : DbContext
    {
        public MegaDesk9GroupContext (DbContextOptions<MegaDesk9GroupContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDesk9Group.Models.DeskQuote> DeskQuote { get; set; }
    }
}
