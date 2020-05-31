using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Mappers;
using ApplicationCore.Mappers.Profiles;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection RegisterAutoMapperService(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new PasswordProfile());
                config.AddProfile(new MessageProfile());
            });

            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
