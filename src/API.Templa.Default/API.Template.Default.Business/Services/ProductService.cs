using API.Template.Default.Business.Interfaces;
using API.Template.Default.Business.Model;
using API.Template.Default.Business.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Template.Default.Business.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(INotifier notifier, IProductRepository productRepository) : base(notifier)
        {
            _productRepository = productRepository;
        }

        public async Task Add(Product product)
        {
            if (!ValidationExecute(new ProdutoValidation(), product)) return;

            if (await _productRepository.GetById(product.Id) != null)
            {
                Notify("Já existe produto com esse Id");
                return;
            }

            await _productRepository.Add(product);
        }

        public async Task Update(Product product, Guid id)
        {
            if (!ValidationExecute(new ProdutoValidation(), product)) return;

            if(await _productRepository.GetById(id) == null)
            {
                Notify("Produto não encontrado");
                return;
            }

            await _productRepository.Update(product);
        }

        public async Task Remove(Guid id)
        {
            var product = await _productRepository.GetById(id);

            if(product == null) return;

            await _productRepository.Remove(id);
        }
    }
}
