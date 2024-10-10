using AutoMapper;
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
        private readonly IMapper _mapper;

        public EfUpdateCommentCommand(ReadilyContext context, IApplicationActor actor, UpdateCommentValidator validator, IMapper mapper) : base(context)
        {
            _actor = actor;
            _validator = validator;
            _mapper = mapper;
        }

        private EfUpdateCommentCommand() { }

        public int Id => 54;

        public string Name => "Update Comment";

        public void Execute(UpdateCommentDto data)
        {
            _validator.ValidateAndThrow(data);

            data.UserId = _actor.Id;

            var comment = Context
                                .Comments
                                .Include(x => x.Images)
                                .First(x => x.Id == data.Id);

            if(comment.UserId != _actor.Id) {
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

            _mapper.Map(data, comment);

            Context.SaveChanges();
        }
    }
}
