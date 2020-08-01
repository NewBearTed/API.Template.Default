using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Templa.Default.Business.Model;

namespace API.Templa.Default.Data.DataBase
{
    public class DefaultDBContext : DbContext
    {
        public DefaultDBContext(DbContextOptions<DefaultDBContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
