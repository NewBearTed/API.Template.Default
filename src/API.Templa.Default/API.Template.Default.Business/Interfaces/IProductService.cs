using API.Template.Default.Business.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Template.Default.Business.Interfaces
{
    public interface IProductService
    {
        Task Add(Product product);

        Task Update(Product product, Guid id);

        Task Remove(Guid id);
    }
}
