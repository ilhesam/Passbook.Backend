using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using DependencyInjection.Middleware;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration config, IMvcBuilder builder)
        {
            services.AddDbContextPool<PassbookDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("PassbookDbConnection")));
           
            services.RegisterIdentityService();

            services.RegisterJwtService(config);

            services.RegisterSwaggerService();

            services.RegisterFluentValidationService(builder);

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserJwtTokenRepository, UserJwtTokenRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IJwtService, JwtService>();

            return services;
        }

        public static IApplicationBuilder EnableMiddlewares(this IApplicationBuilder app)
        {
            app.EnableSwaggerMiddleware();

            return app;
        }
    }
}
