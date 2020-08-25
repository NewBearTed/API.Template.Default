using API.Template.Default.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Template.Default.Business.Services
{
    public class HttpProductService : ProductService, IHttpProductService
    {
        public HttpProductService(INotifier notifier, IProductHttpRepository productRepository) : base(notifier, productRepository)
        {
        }
    }
}
