using API.Template.Default.Extensions.HealthChecks;
using HealthChecks.System;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace API.Template.Default.Configuration
{
    public static class HealthCheckConfig
    {
        public static IServiceCollection AddHealthCheckConfig(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("DefaultDBContext"), name: "My SQLDataBase")
                .AddHealthChecksSystem();

            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.AddHealthCheckEndpoint("SystemX Endpoint", "https://localhost:44377/healthchecks");
            });

            return services;
        }


        public static IApplicationBuilder UseHealthCheckConfig(this IApplicationBuilder app)
        {

            app.UseHealthChecks("/healthchecks", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.UseHealthChecksUI();//Patch => /healthchecks-ui

            return app;
        }
    }
}
