using API.Template.Default.Business.Interfaces;
using API.Template.Default.Business.Model;
using API.Template.Default.Data.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Template.Default.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        public ProductRepository(DefaultDBContext dbContext) : base(dbContext)
        {

        }
    }
}
