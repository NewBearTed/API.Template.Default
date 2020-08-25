using API.Template.Default.Business.Interfaces;
using API.Template.Default.Business.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace API.Template.Default.Data.Repository.Http
{
    public abstract class HttpRepository<TEntity> : IHttpRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _uri;

        public HttpRepository(HttpClient httpClient, string uri)
        {
            _httpClient = httpClient;
            _uri = uri;
        }

        public async Task<List<TEntity>> GetAll()
        {
            string responseBody = string.Empty;

            try
            {
                responseBody = await _httpClient.GetStringAsync(_uri);
            }
            catch
            {
                //TODO:Implementar log
            }

            return JsonConvert.DeserializeObject<List<TEntity>>(responseBody);
        }

        public async Task<TEntity> GetById(Guid id)
        {
            string responseBody = string.Empty;

            try
            {
                responseBody = await _httpClient.GetStringAsync(Path.Combine(_uri, id.ToString()));
            }
            catch
            {
                //TODO:Implementar log
            }

            return JsonConvert.DeserializeObject<TEntity>(responseBody);
        }

        public async Task Add(TEntity entity)
        {
            var content = new StringContent(JsonConvert.SerializeObject(entity));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync(_uri, content);

            if (response.IsSuccessStatusCode)
                entity = JsonConvert.DeserializeObject<TEntity>(await response.Content.ReadAsStringAsync());
        }

        public async Task Update(TEntity entity)
        {
            var content = new StringContent(JsonConvert.SerializeObject(entity));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PutAsync(_uri, content);

            if (response.IsSuccessStatusCode)
                entity = JsonConvert.DeserializeObject<TEntity>(await response.Content.ReadAsStringAsync());
        }

        public async Task Remove(Guid id)
        {
            await _httpClient.DeleteAsync(Path.Combine(_uri, id.ToString()));
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            string responseBody = string.Empty;

            try
            {
                responseBody = await _httpClient.GetStringAsync(_uri);
            }
            catch
            {
                //TODO:Implementar log
            }

            var products = JsonConvert.DeserializeObject<List<TEntity>>(responseBody);

            return products.ToList();
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
