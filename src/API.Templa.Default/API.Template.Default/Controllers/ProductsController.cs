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
using API.Template.Default.Helper;
using System.IO;

namespace API.Template.Default.Controllers
{
    public class ProductsController : MainController
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, IMapper mapper, INotifier notifier, IProductService productService)
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

            await _productService.Update(_mapper.Map<Product>(productViewModel), id);

            if (!string.IsNullOrWhiteSpace(productViewModel.Photo))
                PhotoHelper.SavePhoto(productViewModel.Id, productViewModel.Photo);
            else PhotoHelper.DeletePhoto(productViewModel.Id);

            return CustomResponse(productViewModel);
        }

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> PostProduct(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var product = _mapper.Map<Product>(productViewModel);

            await _productService.Add(product);

            productViewModel.Id = product.Id;

            if (!string.IsNullOrWhiteSpace(productViewModel.Photo))
                PhotoHelper.SavePhoto(productViewModel.Id, productViewModel.Photo);

            return CustomResponse(productViewModel);
        }

        [DisableRequestSizeLimit]
        [HttpPost("UploadLongFile")]
        public async Task<ActionResult> PostUploadLongFile(IFormFile formFile)
        {
            if (formFile == null || formFile.Length == 0)
            {
                NotifyErrors("Forneça uma imagem para este produto!");
                return CustomResponse();
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/LongFiles", formFile.FileName);

            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            return CustomResponse();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task DeleteProduct(Guid id) => await _productService.Remove(id);
    }
}
