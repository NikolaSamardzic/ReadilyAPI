using AutoMapper;
using ReadilyAPI.Application.UseCases.DTO.Biography;
using ReadilyAPI.Application.UseCases.DTO.Books;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile() 
        {
            CreateMap<CreateBookDto, Book>()
                .ForMember(d => d.Image, s => s.MapFrom(x => new Image
                {
                    Src = x.Image,
                    Alt = "Book Image"
                })).ForMember(d => d.BookCategories, s => s.MapFrom(x => x.CategoryIds.Select(cId => new BookCategory
                {
                    CategoryId = cId,
                }))).ForMember(d => d.Prices, s => s.MapFrom(x => new List<Price>
                {
                    new Price
                    {
                        Value = x.Price
                    }
                }));

            CreateMap<UpdateBookDto, Book>()
                .ForMember(d => d.Image, s => s.MapFrom(
                    x => string.IsNullOrEmpty(x.Image)
                                            ? null
                                            : new Image { Src = x.Image, Alt = "Book Image" }))
                .ForMember(d => d.BookCategories, 
                s => 
                s.MapFrom(x => x.CategoryIds.Select(cId => new BookCategory
                {
                    CategoryId = cId,
                })));

            CreateMap<Book, BookDto>()
                .ForMember(d => d.Image, s => s.MapFrom(x => x.Image.Src))
                .ForMember(d => d.Rating, s => s.MapFrom(x => new Rating
                {
                    Stars = x.Reviews.Any() ? (int)x.Reviews.Average(x => x.Stars) : 0,
                    Count = x.Reviews.Count,
                }))
                .ForMember(d => d.Author, s => s.MapFrom(x => new Author
                {
                    Id = x.AuthorId,
                    Name = x.Author.FirstName + " " + x.Author.LastName,
                })).ForMember(d => d.CommentCount, s => s.MapFrom(x => x.Comments.Count))
                .ForMember(d => d.Categories, s => s.MapFrom(x => x.Categories.Select(x => new Application.UseCases.DTO.Books.Category
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image.Src
                })))
                .ForMember(d => d.Publisher, s => s.MapFrom(x => x.Publisher.Name))
                .ForMember(d => d.Pages, s => s.MapFrom(x => x.PageCount))
                .ForMember(d => d.Rating, opt => opt.NullSubstitute(new Rating
                {
                    Stars = 0,
                    Count = 0
                }));

            CreateMap<Book, SmallerBookDto>()
                .ForMember(d => d.Image, s => s.MapFrom(x => x.Image.Src))
                .ForMember(d => d.Author, s => s.MapFrom(x => new Author
                {
                    Id = x.AuthorId,
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
