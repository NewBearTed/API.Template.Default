using API.Template.Default.Business.Interfaces;
using API.Template.Default.Business.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API.Template.Default.Data.Repository.Http
{
    public class ProductHttpRepository : HttpRepository<Product>, IProductHttpRepository
    {
        public ProductHttpRepository(HttpClient httpClient, string uri) : base(httpClient, uri)
        {
        }
    }
}
