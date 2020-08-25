using API.Template.Default.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Template.Default.Business.Services
{
    public class DbProductService : ProductService, IDbProductService
    {
        public DbProductService(INotifier notifier, IProductDbRepository productRepository) : base(notifier, productRepository)
        {
        }
    }
}
