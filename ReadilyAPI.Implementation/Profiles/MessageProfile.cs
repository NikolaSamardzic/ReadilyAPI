using AutoMapper;
using ReadilyAPI.Application.UseCases.DTO.Messages;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile() 
        {
            CreateMap<CreateMessageDto, Message>()
                .ForMember(d => d.Text, s => s.MapFrom(x => x.Message));

            CreateMap<Message, MessageDto>()
                .ForMember(d => d.Message, s => s.MapFrom(x => x.Text))
                .ForMember(d => d.Username, s => s.MapFrom(x => x.User.Username));
        }
    }
}
