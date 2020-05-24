using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Extensions;
using ApplicationCore.ViewModels.Common;
using AutoMapper;
using Domain.Common;
using Microsoft.Extensions.Configuration;

namespace ApplicationCore.Mappers.Resolvers
{
    public class DecryptPasswordResolver<TSource,TDestination> : IValueResolver<TSource, TDestination, string>
    where TSource : IPasswordHashProperty
    where TDestination : IPasswordProperty
    {
        public string Resolve(TSource source, TDestination destination, string destMember, ResolutionContext context)
            => source.PasswordHash.Decrypt();
    }
}
