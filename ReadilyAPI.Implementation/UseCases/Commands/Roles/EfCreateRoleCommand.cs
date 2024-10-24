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
    public class EfCreateRoleCommand : EfCreateUseCase<CreateRoleDto, Role>, ICreateRoleCommand
    {
        public EfCreateRoleCommand(ReadilyContext context, CreateRoleValidator validator, IMapper mapper) : base(context, mapper, validator)
        {
        }

        private EfCreateRoleCommand() { }

        public override int Id => 7;

        public override string Name => "Create Role";
    }
}
