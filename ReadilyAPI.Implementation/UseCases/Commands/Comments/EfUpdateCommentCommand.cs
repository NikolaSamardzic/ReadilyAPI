using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application;
using ReadilyAPI.Application.Exceptions;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReadilyAPI.Implementation.UseCases.Commands.Comments
{
    public class EfUpdateCommentCommand : EfUpdateUseCase<UpdateCommentDto, Comment>, IUpdateCommentCommand
    {
        private readonly IApplicationActor _actor;

        public EfUpdateCommentCommand(ReadilyContext context, IApplicationActor actor, UpdateCommentValidator validator, IMapper mapper) : base(context, mapper, validator)
        {
            _actor = actor;
        }

        private EfUpdateCommentCommand() { }

        public override int Id => 54;

        public override string Name => "Update Comment";

        protected override IQueryable<Comment> IncludeRelatedEntities(IQueryable<Comment> query)
        {
            return query.Include(x => x.Images);
        }

        protected override void BeforeUpdate(UpdateCommentDto data, Comment comment)
        {
            if (comment.UserId != _actor.Id)
            {
                throw new ConflictException("Comment is not created by this user.");
            }

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
