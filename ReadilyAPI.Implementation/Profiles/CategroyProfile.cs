using AutoMapper;
using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.Application.UseCases.DTO.Images;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Profiles
{
    public class CategroyProfile : Profile
    {
        public CategroyProfile() 
        {
            CreateMap<CreateCategoryDto, Category>()
                .ForMember(d => d.Image, s => s.MapFrom(x => new Image
                {
                    Src = x.Image,
                    Alt = "Book Image",
                }));

            CreateMap<UpdateCategoryDto, Category>()
                .ForMember(d => d.Image, s => s.MapFrom(x => new Image
                {
                    Src = x.Image,
                    Alt = "Book Image",
                }));

            CreateMap<Category, CategoryDto>()
                .ForMember(d => d.Image, s => s.MapFrom(x => new ImageDto
                {
                    Src = x.Image.Src,
                    Alt = x.Image.Alt,
                }))
                .ForMember(d => d.Children, opt => opt.MapFrom(src => src.Children.Where(c => c.IsActive))); ;

            CreateMap<Category, ChildCategoryDto>();
        }
    }
}
