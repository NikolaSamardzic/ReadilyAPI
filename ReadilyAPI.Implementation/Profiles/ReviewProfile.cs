using AutoMapper;
using ReadilyAPI.Application.UseCases.DTO.Review;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile() 
        {
            CreateMap<CreateReviewDto, Review>();

            CreateMap<UpdateReviewDto, Review>();
        }
    }
}
