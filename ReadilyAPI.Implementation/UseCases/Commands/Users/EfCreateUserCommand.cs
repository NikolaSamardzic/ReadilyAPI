using AutoMapper;
using FluentValidation;
using ReadilyAPI.Application.Notification;
using ReadilyAPI.Application.UseCases.Commands.Users;
using ReadilyAPI.Application.UseCases.DTO.User;
using ReadilyAPI.DataAccess;
using ReadilyAPI.DataAccess.Migrations;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Cryptography;
using ReadilyAPI.Implementation.Notification;
using ReadilyAPI.Implementation.Validators.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Users
{
    public class EfCreateUserCommand : EfCreateUseCase<CreateUserDto, User>, ICreateUserCommand
    {
        private readonly IEmailService _emailService;

        public EfCreateUserCommand(ReadilyContext context, CreateUserValidator validator, IEmailService emailService, IMapper mapper) : base(context, mapper, validator)
        {
            _emailService = emailService;
        }

        private EfCreateUserCommand() { }

        public override int Id => 34;

        public override string Name => "Create User";

        protected override void BeforeAdd(CreateUserDto data)
        {
            if (string.IsNullOrEmpty(data.Avatar))
            {
                data.AvatarId = Context.Images.First(x => x.Src.Contains("default")).Id;
            }
            else
            {
                var tempFile = Path.Combine("wwwroot", "temp", data.Avatar);
                var destinationFile = Path.Combine("wwwroot", "images", "avatars", data.Avatar);
                System.IO.File.Move(tempFile, destinationFile);
            }

            _emailService.SendEmailAsync(data.Email, "Activate Account", $"http://localhost:5001/users/{user.Token}/verify");
        }
    }
}
