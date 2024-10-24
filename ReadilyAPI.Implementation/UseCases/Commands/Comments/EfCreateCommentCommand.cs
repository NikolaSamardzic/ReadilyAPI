using AutoMapper;
using FluentValidation;
using ReadilyAPI.Application;
using ReadilyAPI.Application.UseCases.Commands.Comments;
using ReadilyAPI.Application.UseCases.DTO.Comments;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Validators.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Comments
{
    public class EfCreateCommentCommand : EfCreateUseCase<CreateCommentDto, Comment>, ICreateCommentCommand
    {
        private readonly IApplicationActor _actor;

        public EfCreateCommentCommand(ReadilyContext context, IApplicationActor actor, CreateCommentValidator validator, IMapper mapper) : base(context, mapper, validator)
        {
            _actor = actor;
        }

        private EfCreateCommentCommand() { }

        public override int Id => 53;

        public override string Name => "Create Comment";

        protected override void BeforeAdd(CreateCommentDto data)
        {
            data.UserId = _actor.Id;

            if (data.Images != null && data.Images.Any())
            {
                foreach (var image in data.Images)
                {
                    var tempFile = Path.Combine("wwwroot", "temp", image);
                    var destinationFile = Path.Combine("wwwroot", "images", "comments", image);
                    System.IO.File.Move(tempFile, destinationFile);
                }
            }
        }
    }
}
