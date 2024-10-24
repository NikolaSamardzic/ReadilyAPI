using AutoMapper;
using FluentValidation;
using ReadilyAPI.Application.Exceptions;
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
    public class EfCreateUserUseCaseCommand : EfCreateUseCase<CreateUserUseCaseDto, Domain.UserUseCase>, ICreateUserUseCaseCommand
    {
        public EfCreateUserUseCaseCommand(ReadilyContext context, CreateUserUseCaseValidator validator, IMapper mapper) : base(context, mapper, validator)
        {
        }

        private EfCreateUserUseCaseCommand() { }

        public override int Id => 44;

        public override string Name => "Create User Use Case";

        protected override bool IsAddRange() => true;

        protected override void BeforeAdd(CreateUserUseCaseDto data)
        {
            var removeUseCases = Context.UserUseCases.Where(x => x.UserId == data.UserId).ToList();
            Context.UserUseCases.RemoveRange(removeUseCases);
        }
    }
}
