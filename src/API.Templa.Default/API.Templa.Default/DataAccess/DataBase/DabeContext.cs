using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Templa.Default.Model;

namespace API.Templa.Default.DataAccess.DataBase
{
    public class DabeContext : DbContext
    {
        public DabeContext (DbContextOptions<DabeContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
