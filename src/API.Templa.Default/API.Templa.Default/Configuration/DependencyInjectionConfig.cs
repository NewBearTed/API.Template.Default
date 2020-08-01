using API.Templa.Default.Business.Interfaces;
using API.Templa.Default.Data.DataBase;
using API.Templa.Default.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Templa.Default.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DefaultDBContext>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
