using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Roles;
using ReadilyAPI.Application.UseCases.DTO.Roles;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Validators.Role;
using ReadilyAPI.DataAccess.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ReadilyAPI.Implementation.UseCases.Commands.Roles
{
    public class EfUpdateRoleCommand : EfUseCase, IUpdateRoleCommand
    {
        private readonly UpdateRoleValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateRoleCommand(ReadilyContext context, UpdateRoleValidator validator, IMapper mapper) : base(context)
        {
            _validator = validator;
            this._mapper = mapper;
        }

        private EfUpdateRoleCommand() { }

        public int Id => 8;

        public string Name => "Update Role";

        public void Execute(UpdateRoleDto data)
        {
            _validator.ValidateAndThrow(data);

            var role = Context.Roles
                .Include(x=>x.RoleUseCases)
                .FirstOrDefault(x=>x.Id == data.Id && x.IsActive);

            if (role == null)
            {
                throw new EntityNotFoundException(data.Id.GetValueOrDefault(), nameof(Domain.Role));
            }

            _mapper.Map(data, role);

            Context.Roles.Update(role);

            Context.SaveChanges();
        }
    }
}
