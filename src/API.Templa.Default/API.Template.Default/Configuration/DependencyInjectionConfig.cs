using API.Template.Default.Business.Interfaces;
using API.Template.Default.Business.Notifications;
using API.Template.Default.Business.Services;
using API.Template.Default.Data.DataBase;
using API.Template.Default.Data.Repository.DataBase;
using API.Template.Default.Data.Repository.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Net.Http;

namespace API.Template.Default.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DefaultDBContext>();
            services.AddScoped<IProductDbRepository, ProductDbRepository>();
            services.AddScoped<IProductHttpRepository>(repo=> new ProductHttpRepository(new HttpClient(), configuration["HttpURIs:APIProductURI"]));
            services.AddScoped<IHttpProductService, HttpProductService>();
            services.AddScoped<IDbProductService, DbProductService>();

            services.AddScoped<INotifier, Notifier>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
