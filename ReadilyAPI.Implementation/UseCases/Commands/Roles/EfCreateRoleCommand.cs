using AutoMapper;
using FluentValidation;
using ReadilyAPI.Application.UseCases.Commands.Roles;
using ReadilyAPI.Application.UseCases.DTO.Roles;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Validators.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Roles
{
    public class EfCreateRoleCommand : EfUseCase, ICreateRoleCommand
    {
        private readonly CreateRoleValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateRoleCommand(ReadilyContext context, CreateRoleValidator validator, IMapper mapper) : base(context)
        {
            _validator = validator;
            this._mapper = mapper;
        }

        private EfCreateRoleCommand() { }

        public int Id => 7;

        public string Name => "Create Role";

        public void Execute(CreateRoleDto data)
        {
            _validator.ValidateAndThrow(data);

            Context.Roles.Add(_mapper.Map<Role>(data));

            Context.SaveChanges();
        }
    }
}
