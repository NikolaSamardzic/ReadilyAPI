using FluentValidation;
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

        public EfUpdateUserCommand(ReadilyContext context, IApplicationActor actor, UpdateUserValidator userValidator) : base(context)
        {
            _actor = actor;
            _validator = userValidator;
        }

        public int Id => 37;

        public string Name => "Update User";

        public void Execute(UpdateUserDto data)
        {
            _validator.ValidateAndThrow(data);

            var user = Context.Users.Find(_actor.Id);

            user.Username = data.Username;
            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.Phone = data.Phone;

            if(user.Role.Name == "Writer")
            {
                user.Biography.Text = data.Biography.Text;
            }

            if(data.Address != null && user.Address != null)
            {
                user.Address.AddressName = data.Address.AddressName;
                user.Address.AddressNumber = data.Address.AddressNumber;
                user.Address.State = data.Address.State;
                user.Address.City= data.Address.City;
                user.Address.Country = data.Address.Country;
                user.Address.PostalCode = data.Address.PostalCode;
            }
            else if(data.Address != null){
                var address = new Domain.Address
                {
                    AddressName = data.Address.AddressName,
                    AddressNumber = data.Address.AddressNumber,
                    State = data.Address.State,
                    City = data.Address.City,
                    Country = data.Address.Country,
                    PostalCode = data.Address.PostalCode,
                };
                user.Address = address;
            }

            if(data.Avatar != null && user.Avatar != null)
            {
                var oldImage = user.Avatar.Src;
                user.Avatar.Src = data.Avatar;

                var tempFile = Path.Combine("wwwroot", "temp", data.Avatar);
                var destinationFile = Path.Combine("wwwroot", "images", "avatars", data.Avatar);
                System.IO.File.Move(tempFile, destinationFile);
                System.IO.File.Delete(oldImage);
            }
            else if(data.Avatar != null)
            {
                user.Avatar = new Domain.Image
                {
                    Src = data.Avatar,
                    Alt = "User avatar"
                };

                var tempFile = Path.Combine("wwwroot", "temp", data.Avatar);
                var destinationFile = Path.Combine("wwwroot", "images", "avatars", data.Avatar);
                System.IO.File.Move(tempFile, destinationFile);
            }

            Context.SaveChanges();
        }
    }
}
