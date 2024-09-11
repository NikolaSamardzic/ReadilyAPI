using FluentValidation;
using ReadilyAPI.Application;
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
    public class EfCreateCommentCommand : EfUseCase, ICreateCommentCommand
    {
        private readonly IApplicationActor _actor;
        private readonly CreateCommentValidator _validator;

        public EfCreateCommentCommand(ReadilyContext context, IApplicationActor actor, CreateCommentValidator validator) : base(context)
        {
            _actor = actor;
            _validator = validator;
        }

        private EfCreateCommentCommand() { }

        public int Id => 53;

        public string Name => "Create Comment";

        public void Execute(CreateCommentDto data)
        {
            _validator.ValidateAndThrow(data);

            var comment = new Domain.Comment
            {
                UserId = _actor.Id,
                BookId = data.BookId,
                Text = data.Text,
            };

            if(data.Images != null &&  data.Images.Any()) {
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

            Context.Comments.Add(comment);

            Context.SaveChanges();
        }
    }
}
