using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Roles;
using ReadilyAPI.Application.UseCases.DTO.Roles;
using ReadilyAPI.DataAccess;
using ReadilyAPI.DataAccess.Migrations;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Validators.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Roles
{
    public class EfUpdateRoleCommand : EfUseCase, IUpdateRoleCommand
    {
        private readonly UpdateRoleValidator _validator;

        public EfUpdateRoleCommand(ReadilyContext context, UpdateRoleValidator validator) : base(context)
        {
            _validator = validator;
        }

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

            foreach (RoleUseCase useCase in role.RoleUseCases)
            {
                Context.RoleUseCases.Remove(useCase);
            }

            role.Name = data.Name;
            role.RoleUseCases = data.RoleUseCases.Select(useCaseId => new Domain.RoleUseCase
            {
                UseCaseId = useCaseId,
            }).ToList();

            Context.SaveChanges();
        }
    }
}
