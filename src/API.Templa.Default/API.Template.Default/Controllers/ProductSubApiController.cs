
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Template.Default.Business.Interfaces;
using API.Template.Default.Business.Model;
using API.Template.Default.Business.Services;
using API.Template.Default.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Template.Default.Controllers
{
    public class ProductSubApiController : MainController
    {
        private readonly IProductHttpRepository _productHttpRepository;
        private readonly IHttpProductService _productService;
        private readonly IMapper _mapper;

        public ProductSubApiController(IMapper mapper, INotifier notifier, IHttpProductService productService, ILogger<ProductSubApiController> logger, IProductHttpRepository productHttpRepository)
            : base(notifier, logger)
        {
            _mapper = mapper;
            _productService = productService;
            _productHttpRepository = productHttpRepository;
        }

        // GET: api/<ProductSubApiController>
        [HttpGet]
        public async Task<IEnumerable<ProductViewModel>> Get()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productHttpRepository.GetAll());
        }

        // GET api/<ProductSubApiController>/5
        [HttpGet("{id}")]
        public async Task<ProductViewModel> Get(Guid id)
        {
            return _mapper.Map<ProductViewModel>(await _productHttpRepository.GetById(id));
        }

        // POST api/<ProductSubApiController>
        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> PostProduct(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var product = _mapper.Map<Product>(productViewModel);

            await _productService.Add(product);

            productViewModel.Id = product.Id;

            //if (!string.IsNullOrWhiteSpace(productViewModel.Photo))
            //    PhotoHelper.SavePhoto(productViewModel.Id, productViewModel.Photo);

            return CustomResponse(productViewModel);
        }

        // PUT api/<ProductSubApiController>/5
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

            //if (!string.IsNullOrWhiteSpace(productViewModel.Photo))
            //    PhotoHelper.SavePhoto(productViewModel.Id, productViewModel.Photo);
            //else PhotoHelper.DeletePhoto(productViewModel.Id);

            return CustomResponse(productViewModel);
        }

        // DELETE api/<ProductSubApiController>/5
        [HttpDelete("{id}")]
        public async Task DeleteProduct(Guid id) => await _productService.Remove(id);
    }
}
