using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Template.Default.Configuration
{
    public static class HealthCheckConfig
    {
        public static IServiceCollection AddHealthCheckConfig(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("DefaultDBContext"), name: "SQLDataBase");

            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.AddHealthCheckEndpoint("SystemX Endpoint", "http://remoteendpoint:9000/healthz");
            });

            return services;
        }

        
        public static IApplicationBuilder UseHealthCheckConfig(this IApplicationBuilder app)
        {

            app.UseHealthChecks("/healthchecks", new HealthCheckOptions { 
                Predicate = _=> true,
                ResponseWriter =UIResponseWriter.WriteHealthCheckUIResponse 
            });
            app.UseHealthChecksUI();//Patch => /healthchecks-ui

            return app;
        }
    }
}
