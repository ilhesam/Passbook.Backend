using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Mappers.Resolvers;
using ApplicationCore.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace ApplicationCore.Mappers.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageGetDto>()
                .ForMember(dest => dest.CreatedPersianDateTime,
                    opt => opt.MapFrom<CreatedPersianDateTimeResolver<Message, MessageGetDto>>())
                .ForMember(dest => dest.UpdatedPersianDateTime,
                    opt => opt.MapFrom<UpdatedPersianDateTimeResolver<Message, MessageGetDto>>());

            CreateMap<Message, MessageEditDto>();

            CreateMap<MessageEditDto, Message>();

            CreateMap<MessageAddDto, Message>();
        }
    }
}
