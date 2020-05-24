using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Validators;
using ApplicationCore.Validators.Password;
using ApplicationCore.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IServiceCollection RegisterFluentValidationService(this IServiceCollection services, IMvcBuilder builder)
        {
            builder.AddFluentValidation();

            services.AddTransient<IValidator<RegisterDto>, RegisterDtoValidator>();
            services.AddTransient<IValidator<LoginDto>, LoginDtoValidator>();

            services.AddTransient<IValidator<PasswordAddDto>, PasswordAddDtoValidator>();
            services.AddTransient<IValidator<PasswordEditDto>, PasswordEditDtoValidator>();

            return services;
        }
    }
}
