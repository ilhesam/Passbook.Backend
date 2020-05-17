using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DependencyInjection.Middleware
{
    public static class JwtExtensions
    {
        public static IServiceCollection RegisterJwtService(this IServiceCollection services, IConfiguration config)
        {
            var issuer = config?["Jwt:Issuer"];
            var key = config?["Jwt:Key"];

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = async context =>
                        {
                            string authHeader = context.HttpContext.Request.Headers["Authorization"];

                            if (authHeader != null)
                            {
                                if (authHeader.StartsWith("Bearer "))
                                {
                                    var token = authHeader.Substring("Bearer ".Length);

                                    var jwtService =
                                        context.HttpContext.RequestServices.GetRequiredService<IJwtService>();

                                    if (await jwtService.IsExistTokenAsync(token))
                                    {
                                        context.Success();
                                        return;
                                    }
                                }
                            }

                            context.Fail("توکن وارد شده اعتبار ندارد");
                        }
                    };
                });

            return services;
        }
    }
}
