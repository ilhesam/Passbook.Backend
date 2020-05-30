using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Extensions;
using ApplicationCore.ViewModels;
using AutoMapper;
using Domain.Common;

namespace ApplicationCore.Mappers.Resolvers
{
    public class UpdatedPersianDateTimeResolver<TSource, TDestination> : IValueResolver<TSource, TDestination, string>
        where TSource : Entity
        where TDestination : EntityGetDto
    {
        public string Resolve(TSource source, TDestination destination, string destMember, ResolutionContext context)
            => source.UpdatedDateTime.ToPersianDateTime();
    }
}
