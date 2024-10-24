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
    public class EfCreateUserFavoriteCategoriesCommand : EfCreateUseCase<CreateUserFavoriteCategoriesDto, UserCategory>, ICreateUserFavoriteCategoriesCommand
    {
        public EfCreateUserFavoriteCategoriesCommand(ReadilyContext context, CreateUserFavoriteCategoriesValidator validator, IMapper mapper) : base(context, mapper, validator)
        {
        }

        private EfCreateUserFavoriteCategoriesCommand() { }

        public override int Id => 43;

        public override string Name => "Create User Favorite Categories";

        protected override bool IsAddRange() => true;
    }
}
