using AutoMapper;
using ReadilyAPI.Application.UseCases.DTO.Wishlists;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Profiles
{
    public class WishlistProfile : Profile
    {
        public WishlistProfile() 
        {
            CreateMap<CreateWishlistDto, Wishlist>();

            CreateMap<Book, WishlistDto>()
                .ForMember(d => d.Image, s => s.MapFrom(x => x.Image.Src))
                .ForMember(d => d.Author, s => s.MapFrom(x => new Author
                {
                    Id = x.Author.Id,
                    Name = x.Author.FirstName + " " + x.Author.LastName,
                }))
                .ForMember(d => d.Rating, s => s.MapFrom(x => new Rating
                {
                    Stars = x.Reviews.Any() ? (int)x.Reviews.Average(x => x.Stars) : 0,
                    Count = x.Reviews.Count,
                }))
                .ForMember(d => d.Rating, opt => opt.NullSubstitute(new Rating
                {
                    Stars = 0,
                    Count = 0
                }));
        }
    }
}
