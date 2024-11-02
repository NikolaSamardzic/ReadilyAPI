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

            CreateMap<Wishlist, WishlistDto>()
                .ForMember(x => x.Id, s => s.MapFrom(x => x.Id))
                .ForMember(x => x.Title, s => s.MapFrom(x => x.Book.Title))
                .ForMember(d => d.Image, s => s.MapFrom(x => x.Book.Image.Src))
                .ForMember(d => d.Author, s => s.MapFrom(x => new Author
                {
                    Id = x.Book.Author.Id,
                    Name = x.Book.Author.FirstName + " " + x.Book.Author.LastName,
                }))
                .ForMember(d => d.Rating, s => s.MapFrom(x => new Rating
                {
                    Stars = x.Book.Reviews.Any() ? (int)x.Book.Reviews.Average(x => x.Stars) : 0,
                    Count = x.Book.Reviews.Count,
                }))
                .ForMember(d => d.Rating, opt => opt.NullSubstitute(new Rating
                {
                    Stars = 0,
                    Count = 0
                }));
        }
    }
}
