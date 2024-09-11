using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.DTO.Comments;
using ReadilyAPI.Application.UseCases.DTO.Images;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfFindCommentQuery : EfUseCase, IFindCommentQuery
    {
        public EfFindCommentQuery(ReadilyContext context) : base(context)
        {
        }

        private EfFindCommentQuery() { }

        public int Id => 56;

        public string Name => "Find Comment";

        public CommentDto Execute(int search)
        {
            var comment = Context
                .Comments
                .Include(x => x.User)
                .ThenInclude(x => x.Avatar)
                .Include(x=>x.Images)
                .Include(x => x.Book)
                .ThenInclude(x => x.Reviews)
                .FirstOrDefault(x => x.Id == search && x.IsActive);

            if(comment == null)
            {
                throw new EntityNotFoundException(search, nameof(Domain.Comment));
            }

            return new CommentDto
            {
                Id = comment.Id,
                Text = comment.Text,
                CreatedAt = comment.CreatedAt,
                Rating = comment.Book.Reviews.FirstOrDefault(x => x.UserId == comment.UserId)?.Stars ?? 0,
                Images = comment.Images.Select(i => new ImageDto
                {
                    Alt = i.Alt,
                    Src = i.Src,
                }),
                UserComment = new UserCommentDto
                {
                    Id = comment.UserId,
                    Username = comment.User.Username,
                    Avatar = new ImageDto
                    {
                        Src = comment.User.Avatar.Src,
                        Alt = comment.User.Avatar.Alt,
                    }
                }
            };
        }
    }
}
