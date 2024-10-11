using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.Commands.Users;
using ReadilyAPI.Application.UseCases.DTO.User;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
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
        private readonly IMapper _mapper;

        public EfCreateUserFavoriteCategoriesCommand(ReadilyContext context, CreateUserFavoriteCategoriesValidator validator, IMapper mapper) : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        private EfCreateUserFavoriteCategoriesCommand() { }

        public int Id => 43;

        public string Name => "Create User Favorite Categories";

        public void Execute(CreateUserFavoriteCategoriesDto data)
        {
            _validator.ValidateAndThrow(data);

            var userCategories = _mapper.Map<IEnumerable<UserCategory>>(data);

            foreach(var category in userCategories)
            {
                Context.UsersCategories.Add(category);
            }

            Context.SaveChanges();
        }
    }
}
