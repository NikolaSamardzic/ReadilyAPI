using FluentValidation;
using ReadilyAPI.Application.Exceptions;
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
    public class EfCreateUserUseCaseCommand : EfUseCase, ICreateUserUseCaseCommand
    {
        private readonly CreateUserUseCaseValidator _validator;

        public EfCreateUserUseCaseCommand(ReadilyContext context, CreateUserUseCaseValidator validator) : base(context)
        {
            _validator = validator;
        }

        private EfCreateUserUseCaseCommand() { }

        public int Id => 44;

        public string Name => "Create User Use Case";

        public void Execute(CreateUserUseCaseDto data)
        {
            _validator.ValidateAndThrow(data);

            var useCases = Context.UserUseCases.Where(x=>x.UserId == data.UserId).ToList();
            Context.UserUseCases.RemoveRange(useCases);

            foreach(var useCase in data.UserUseCases)
            {
                Context.UserUseCases.Add(new Domain.UserUseCase
                {
                    UserId = data.UserId,
                    UseCaseId = useCase.UseCaseId,
                    Status = useCase.Status,
                });
            }

            Context.SaveChanges();
        }
    }
}
