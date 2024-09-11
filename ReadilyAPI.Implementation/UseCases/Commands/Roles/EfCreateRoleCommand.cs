using FluentValidation;
using ReadilyAPI.Application.UseCases.Commands.Roles;
using ReadilyAPI.Application.UseCases.DTO.Roles;
using ReadilyAPI.DataAccess;
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

        public EfCreateRoleCommand(ReadilyContext context, CreateRoleValidator validator) : base(context)
        {
            _validator = validator;
        }

        private EfCreateRoleCommand() { }

        public int Id => 7;

        public string Name => "Create Role";

        public void Execute(CreateRoleDto data)
        {
            _validator.ValidateAndThrow(data);

            Context.Roles.Add(new Domain.Role()
            {
                Name = data.Name,
                RoleUseCases = data.RoleUseCases.Select(useCaseId => new Domain.RoleUseCase
                {
                    UseCaseId = useCaseId,
                }).ToList()
            });

            Context.SaveChanges();
        }
    }
}
