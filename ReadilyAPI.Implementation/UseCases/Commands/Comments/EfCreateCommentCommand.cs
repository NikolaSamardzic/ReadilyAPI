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
    public class EfCreateCommentCommand : EfUseCase, ICreateCommentCommand
    {
        private readonly IApplicationActor _actor;
        private readonly CreateCommentValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateCommentCommand(ReadilyContext context, IApplicationActor actor, CreateCommentValidator validator, IMapper mapper) : base(context)
        {
            _actor = actor;
            _validator = validator;
            _mapper = mapper;
        }

        private EfCreateCommentCommand() { }

        public int Id => 53;

        public string Name => "Create Comment";

        public void Execute(CreateCommentDto data)
        {
            _validator.ValidateAndThrow(data);

            data.UserId = _actor.Id;

            if(data.Images != null &&  data.Images.Any()) {
                foreach (var image in data.Images)
                {
                    var tempFile = Path.Combine("wwwroot", "temp", image);
                    var destinationFile = Path.Combine("wwwroot", "images", "comments", image);
                    System.IO.File.Move(tempFile, destinationFile);
                }
            }

            Context.Comments.Add(_mapper.Map<Comment>(data));

            Context.SaveChanges();
        }
    }
}
