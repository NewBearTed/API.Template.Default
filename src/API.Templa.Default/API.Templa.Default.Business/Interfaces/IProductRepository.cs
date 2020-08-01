using API.Templa.Default.Business.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Templa.Default.Business.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetProduc(Guid id);
    }
}
