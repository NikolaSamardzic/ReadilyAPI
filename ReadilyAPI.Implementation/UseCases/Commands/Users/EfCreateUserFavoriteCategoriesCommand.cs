using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.Commands.Users;
using ReadilyAPI.Application.UseCases.DTO.User;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Implementation.Validators.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Users
{
    public class EfCreateUserFavoriteCategoriesCommand : EfUseCase, ICreateUserFavoriteCategoriesCommand
    {
        private readonly CreateUserFavoriteCategoriesValidator _validator;

        public EfCreateUserFavoriteCategoriesCommand(ReadilyContext context, CreateUserFavoriteCategoriesValidator validator) : base(context)
        {
            _validator = validator;
        }

        private EfCreateUserFavoriteCategoriesCommand() { }

        public int Id => 43;

        public string Name => "Create User Favorite Categories";

        public void Execute(CreateUserFavoriteCategoriesDto data)
        {
            _validator.ValidateAndThrow(data);

            foreach(var category in data.CategoryIds)
            {
                Context.UsersCategories.Add(new Domain.UserCategory
                {
                    UserId = data.UserId,
                    CategoryId = category
                });
            }

            Context.SaveChanges();
        }
    }
}
