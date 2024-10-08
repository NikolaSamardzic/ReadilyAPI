using AutoMapper;
using ReadilyAPI.Application.UseCases.DTO.Publisher;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Profiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile() 
        {
            CreateMap<CreatePublisherDto, Publisher>();

            CreateMap<UpdatePublisherDto, Publisher>();

            CreateMap<Publisher, PublisherDto>()
                .ForMember(d => d.BookCount, s => s.MapFrom(x => x.Books.Count));
        }
    }
}
