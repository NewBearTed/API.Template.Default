using API.Template.Default.Business.Interfaces;
using API.Template.Default.Business.Model;
using API.Template.Default.Data.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Template.Default.Data.Repository.DataBase
{
    public class ProductDbRepository : DbRepository<Product>, IProductDbRepository
    {

        public ProductDbRepository(DefaultDBContext dbContext) : base(dbContext)
        {

        }
    }
}
