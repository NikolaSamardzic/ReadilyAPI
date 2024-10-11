using AutoMapper;
using ReadilyAPI.Application.UseCases.DTO.Comments;
using ReadilyAPI.Application.UseCases.DTO.Images;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile() 
        {
            CreateMap<CreateCommentDto, Comment>()
                .ForMember(d => d.Images, s => s.MapFrom(x => x.Images.Select(i => new Image
                {
                    Src = i,
                    Alt = "Comment Image",
                })));

            CreateMap<UpdateCommentDto, Comment>()
                .ForMember(d => d.Images, s => s.MapFrom(x => x.Images.Select(i => new Image
                {
                    Src = i,
                    Alt = "Comment Image",
                })));

            CreateMap<Comment, CommentDto>()
                .ForMember(d => d.Rating, s => s.MapFrom(x => CalculateRating(x)))
                .ForMember(d => d.UserComment, s => s.MapFrom(x => new UserCommentDto
                {
                    Id = x.UserId,
                    Username = x.User.Username,
                    Avatar = new ImageDto
                    {
                        Src = x.User.Avatar.Src,
                        Alt = x.User.Avatar.Alt,
                    }
                }))
                .ForMember(d => d.Images, s => s.MapFrom(x => x.Images.Select(x => new ImageDto
                {
                    Src = x.Src,
                    Alt = x.Alt,
                })));
        }

        private int CalculateRating(Comment c)
        {
            return c.Book.Reviews.FirstOrDefault(r => r.UserId == c.UserId)?.Stars ?? 0;
        }
    }
}
