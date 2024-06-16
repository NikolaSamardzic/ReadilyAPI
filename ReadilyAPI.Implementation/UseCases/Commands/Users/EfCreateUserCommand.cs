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

        public EfCreateUserCommand(ReadilyContext context, CreateUserValidator validator, IEmailService emailService) : base(context)
        {
            _validator = validator;
            _emailService = emailService;
        }

        public int Id => 34;

        public string Name => "Create User";

        public void Execute(CreateUserDto data)
        {
            _validator.ValidateAndThrow(data);

            User user = new User
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                Email = data.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(data.Password),
                Username = data.Username,
                Phone = data.Phone,
                RoleId = data.RoleId,
                Token = TokenGenerator.GenerateRandomToken(30)
            };

            if (string.IsNullOrEmpty(data.Avatar))
            {
                user.Avatar = Context.Images.First(x => x.Src.Contains("default"));
            }
            else
            {
                user.Avatar = new Image
                {
                    Src = data.Avatar,
                    Alt = "User avatar"
                };

                var tempFile = Path.Combine("wwwroot", "temp", data.Avatar);
                var destinationFile = Path.Combine("wwwroot", "images", "avatars", data.Avatar);
                System.IO.File.Move(tempFile, destinationFile);
            }

            Address address = null;
            if (data.Address != null)
            {
                address = new Address
                {
                    AddressName = data.Address.AddressName,
                    AddressNumber = data.Address.AddressNumber,
                    City = data.Address.City,
                    State = data.Address.State,
                    Country = data.Address.Country,
                    PostalCode = data.Address.PostalCode,
                };
            }

            Biography biography = null; 
            if(Context.Roles.First(x=>x.Id == data.RoleId).Name == "Writer")
            {
                biography = new Biography
                {
                    Text = data.Biography.Text,
                };
            }

            user.Address = address;
            user.Biography = biography;

            _emailService.SendEmailAsync(user.Email, "Activate Account", $"http://localhost:5001/users/{user.Token}/verify");

            Context.Users.Add( user );

            Context.SaveChanges();
        }
    }
}
