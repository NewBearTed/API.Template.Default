using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Template.Default.Business.Interfaces;
using API.Template.Default.Business.Model;
using API.Template.Default.ViewModels;
using API.Template.Default.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Template.Default.Business.Services;

namespace API.Template.Default.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : MainController
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper, INotifier notifier, ProductService productService)
            : base(notifier)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<ProductViewModel>> GetProduct()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetAll());
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ProductViewModel> GetProduct(Guid id)
        {
            return _mapper.Map<ProductViewModel>(await _productRepository.GetById(id));

        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
            {
                NotifyErrors("O id do produto não pertence a esse produto.");
                return CustomResponse(productViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _productService.Update(_mapper.Map<Product>(productViewModel));


            return CustomResponse(productViewModel);
        }

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> PostProduct(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _productService.Add(_mapper.Map<Product>(productViewModel));

            return CustomResponse(productViewModel);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductViewModel>> DeleteProduct(Guid id)
        {
            var productViewModel = _mapper.Map<ProductViewModel>(await _productRepository.GetById(id));

            if (productViewModel == null)
            {
                return NotFound();
            }

            await _productRepository.Remove(id);

            return CustomResponse(productViewModel);
        }
    }
}
