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
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        public ProductRepository(DefaultDBContext dbContext) : base(dbContext)
        {

        }
    }
}
