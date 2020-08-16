using API.Template.Default.CustomMiddleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Template.Default.Configuration
{
    public static class CustomMiddleware
    {
        public static IApplicationBuilder AddCustomMiddleware(this IApplicationBuilder app)
        {
            //Logg all request
            app.UseMiddleware<RequestLoggingMiddleware>();

            return app;
        }
    }
}
