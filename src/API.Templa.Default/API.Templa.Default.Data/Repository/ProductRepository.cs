using API.Templa.Default.Business.Interfaces;
using API.Templa.Default.Business.Model;
using API.Templa.Default.Data.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Templa.Default.Data.Repository
{
    public class ProductReposiptory : Repository<Product>, IProductRepository
    {

        public ProductReposiptory(DefaultDBContext dbContext) : base(dbContext)
        {

        }

        public async Task<Product> GetProduc(Guid id)
        {
            return await Db.Product.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
