using AutoMapper;
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
        private readonly IMapper _mapper;

        public EfCreateUserUseCaseCommand(ReadilyContext context, CreateUserUseCaseValidator validator, IMapper mapper) : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        private EfCreateUserUseCaseCommand() { }

        public int Id => 44;

        public string Name => "Create User Use Case";

        public void Execute(CreateUserUseCaseDto data)
        {
            _validator.ValidateAndThrow(data);

            var removeUseCases = Context.UserUseCases.Where(x=>x.UserId == data.UserId).ToList();
            Context.UserUseCases.RemoveRange(removeUseCases);

            var useCases = _mapper.Map<IEnumerable<Domain.UserUseCase>>(data);

            foreach(var useCase in useCases)
            {
                Context.UserUseCases.Add(useCase);
            }

            Context.SaveChanges();
        }
    }
}
