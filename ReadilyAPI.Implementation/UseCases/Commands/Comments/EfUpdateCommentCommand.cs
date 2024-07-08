using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Comments;
using ReadilyAPI.Application.UseCases.DTO.Comments;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Implementation.Validators.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Comments
{
    public class EfUpdateCommentCommand : EfUseCase, IUpdateCommentCommand
    {
        private readonly IApplicationActor _actor;
        private readonly UpdateCommentValidator _validator;

        public EfUpdateCommentCommand(ReadilyContext context, IApplicationActor actor, UpdateCommentValidator validator) : base(context)
        {
            _actor = actor;
            _validator = validator;
        }

        public int Id => 54;

        public string Name => "Update Comment";

        public void Execute(UpdateCommentDto data)
        {
            _validator.ValidateAndThrow(data);

            var comment = Context
                                .Comments
                                .Include(x => x.Images)
                                .First(x => x.Id == data.Id);

            if(comment.UserId != _actor.Id) {
                throw new ConflictException("Comment is not created by this user.");
            }

            foreach(var image in comment.Images)
            {
                var path = Path.Combine("wwwroot", "images", "comments", image.Src);

                System.IO.File.Delete(path);
            }

            Context.Images.RemoveRange(comment.Images);

            comment.Text = data.Text;

            if (data.Images != null && data.Images.Any())
            {
                comment.Images = data.Images.Select(i => new Domain.Image
                {
                    Src = i,
                    Alt = "Comment Image"
                }).ToList();

                foreach (var image in data.Images)
                {
                    var tempFile = Path.Combine("wwwroot", "temp", image);
                    var destinationFile = Path.Combine("wwwroot", "images", "comments", image);
                    System.IO.File.Move(tempFile, destinationFile);
                }
            }

            Context.SaveChanges();
        }
    }
}
