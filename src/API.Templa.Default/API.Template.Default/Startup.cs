using API.Template.Default.Configuration;
using API.Template.Default.Data.DataBase;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Template.Default
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DefaultDBContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultDBContext")));

            services.AddApiConfig();

            services.AddSwaggerConfig();

            services.AddAutoMapper(typeof(Startup));

            services.AddHealthCheckConfig(Configuration);

            services.ResolveDependencies(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseApiConfig(env);

            app.UseSwaggerConfig(provider);

            app.UseHealthCheckConfig();
        }
    }
}
