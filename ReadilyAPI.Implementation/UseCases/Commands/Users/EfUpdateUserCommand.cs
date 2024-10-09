using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application;
using ReadilyAPI.Application.UseCases.Commands.Users;
using ReadilyAPI.Application.UseCases.DTO.User;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Implementation.Validators.User;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Users
{
    public class EfUpdateUserCommand : EfUseCase, IUpdateUserCommand
    {
        private readonly IApplicationActor _actor;
        private readonly UpdateUserValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateUserCommand(ReadilyContext context, IApplicationActor actor, UpdateUserValidator userValidator, IMapper mapper) : base(context)
        {
            _actor = actor;
            _validator = userValidator;
            _mapper = mapper;
        }

        private EfUpdateUserCommand() { }

        public int Id => 37;

        public string Name => "Update User";

        public void Execute(UpdateUserDto data)
        {
            _validator.ValidateAndThrow(data);

            var user = Context.Users
                .Include(x=>x.Role)
                .Include(x=>x.Avatar)
                .Include(x=>x.Biography)
                .Include(x=>x.Address)
                .First(x=> x.Id == _actor.Id);

            var oldImage = Path.Combine("wwwroot", "images", "avatars", user.Avatar.Src);

            _mapper.Map(data, user);

            if (data.Avatar != null && user.Avatar != null)
            {
                var tempFile = Path.Combine("wwwroot", "temp", data.Avatar);
                var destinationFile = Path.Combine("wwwroot", "images", "avatars", data.Avatar);
                System.IO.File.Move(tempFile, destinationFile);
                System.IO.File.Delete(oldImage);
            }
            else if(data.Avatar != null)
            {
                var tempFile = Path.Combine("wwwroot", "temp", data.Avatar);
                var destinationFile = Path.Combine("wwwroot", "images", "avatars", data.Avatar);
                System.IO.File.Move(tempFile, destinationFile);
            }
            else
            {
                user.Avatar = Context.Images.First(x => x.Src.Contains("default"));
            }

            Context.SaveChanges();
        }
    }
}
