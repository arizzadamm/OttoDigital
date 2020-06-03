using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gas_Online.Models;

namespace GasOnline.Data
{
    public class GasOnlineContext : DbContext
    {
        public GasOnlineContext (DbContextOptions<GasOnlineContext> options)
            : base(options)
        {
        }

        public DbSet<Gas_Online.Models.Gas> Gas { get; set; }
    }
}
