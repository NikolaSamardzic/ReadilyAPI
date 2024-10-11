using AutoMapper;
using FluentValidation;
using ReadilyAPI.Application.Notification;
using ReadilyAPI.Application.UseCases.Commands.Users;
using ReadilyAPI.Application.UseCases.DTO.User;
using ReadilyAPI.DataAccess;
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
    public class EfCreateUserCommand : EfUseCase, ICreateUserCommand
    {
        private readonly CreateUserValidator _validator;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public EfCreateUserCommand(ReadilyContext context, CreateUserValidator validator, IEmailService emailService, IMapper mapper) : base(context)
        {
            _validator = validator;
            _emailService = emailService;
            _mapper = mapper;
        }

        private EfCreateUserCommand() { }

        public int Id => 34;

        public string Name => "Create User";

        public void Execute(CreateUserDto data)
        {
            _validator.ValidateAndThrow(data);

            var user = _mapper.Map<User>(data);

            if (string.IsNullOrEmpty(data.Avatar))
            {
                user.Avatar = Context.Images.First(x => x.Src.Contains("default"));
            }
            else
            {
                var tempFile = Path.Combine("wwwroot", "temp", data.Avatar);
                var destinationFile = Path.Combine("wwwroot", "images", "avatars", data.Avatar);
                System.IO.File.Move(tempFile, destinationFile);
            }

            _emailService.SendEmailAsync(user.Email, "Activate Account", $"http://localhost:5001/users/{user.Token}/verify");

            Context.Users.Add( user );

            Context.SaveChanges();
        }
    }
}
