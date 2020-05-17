using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace DependencyInjection.Middleware
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection RegisterSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Passbook API",
                    Version = "v1"
                });
            });

            return services;
        }

        public static IApplicationBuilder EnableSwaggerMiddleware(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Passbook API V1");
            });

            return app;
        }
    }
}
