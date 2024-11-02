using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application;
using ReadilyAPI.Application.UseCases.Commands.Users;
using ReadilyAPI.Application.UseCases.DTO.User;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Validators.User;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Users
{
    public class EfUpdateUserCommand : EfUpdateUseCase<UpdateUserDto, Domain.User>, IUpdateUserCommand
    {
        private readonly IApplicationActor _actor;

        public EfUpdateUserCommand(ReadilyContext context, IApplicationActor actor, UpdateUserValidator validator, IMapper mapper) : base(context, mapper, validator)
        {
            _actor = actor;
        }

        private EfUpdateUserCommand() { }

        public override int Id => 37;

        public override string Name => "Update User";

        protected override IQueryable<User> IncludeRelatedEntities(IQueryable<User> query)
        {
            return query
                .Include(x => x.Role)
                .Include(x => x.Avatar)
                .Include(x => x.Biography)
                .Include(x => x.Address);
        }

        protected override void BeforeUpdate(UpdateUserDto data, Domain.User user)
        {
            var oldImage = Path.Combine("wwwroot", "images", "avatars", user.Avatar.Src);

            if (data.Avatar != null && user.Avatar != null)
            {
                var tempFile = Path.Combine("wwwroot", "temp", data.Avatar);
                var destinationFile = Path.Combine("wwwroot", "images", "avatars", data.Avatar);
                System.IO.File.Move(tempFile, destinationFile);
                System.IO.File.Delete(oldImage);
            }
            else if (data.Avatar != null)
            {
                var tempFile = Path.Combine("wwwroot", "temp", data.Avatar);
                var destinationFile = Path.Combine("wwwroot", "images", "avatars", data.Avatar);
                System.IO.File.Move(tempFile, destinationFile);
            }
            else
            {
                user.Avatar = Context.Images.First(x => x.Src.Contains("default"));
            }
        }
    }
}
