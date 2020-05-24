using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Extensions;
using ApplicationCore.Mappers.Resolvers;
using ApplicationCore.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace ApplicationCore.Mappers
{
    public class PasswordProfile : Profile
    {
        public PasswordProfile()
        {
            CreateMap<Password, PasswordGetDto>()
                .ForMember(dest => dest.Password,
                    opt => opt.MapFrom<DecryptPasswordResolver<Password, PasswordGetDto>>());

            CreateMap<Password, PasswordEditDto>()
                .ForMember(dest => dest.Password,
                    opt => opt.MapFrom<DecryptPasswordResolver<Password, PasswordEditDto>>());

            CreateMap<PasswordEditDto, Password>()
                .ForMember(dest => dest.PasswordHash,
                    opt => opt.MapFrom<EncryptPasswordResolver<PasswordEditDto, Password>>());

            CreateMap<PasswordAddDto, Password>()
                .ForMember(dest => dest.PasswordHash,
                    opt => opt.MapFrom<EncryptPasswordResolver<PasswordAddDto, Password>>());
        }
    }
}
