using API.Template.Default.Business.Interfaces;
using API.Template.Default.Business.Notifications;
using API.Template.Default.Business.Services;
using API.Template.Default.Data.DataBase;
using API.Template.Default.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace API.Template.Default.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DefaultDBContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<INotifier, Notifier>();

            return services;
        }
    }
}
