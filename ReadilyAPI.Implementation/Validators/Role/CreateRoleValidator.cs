using FluentValidation;
using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.Application.UseCases.DTO.Roles;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Implementation.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Validators.Role
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleDto>
    {
        private readonly ReadilyContext _context;

        public CreateRoleValidator(ReadilyContext context)
        {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Role name is required.")
                .MinimumLength(3)
                .WithMessage("Min number of characters is 3.")
                .Must(name => !_context.Roles.Any(x => x.Name == name))
                .WithMessage("Role name is in use.");

            When(x => x.RoleUseCases.Any(), () =>
            {
                RuleFor(x => x.RoleUseCases)
                .Must(x => x.Min() > 0)
                .WithMessage("Use case doesn't exist")
                .Must(x => x.Max() <= UseCaseInfo.MaxUseCaseId)
                .WithMessage("Use case doesn't exist")
                .Must(x => x.Distinct().Count() == x.Count())
                .WithMessage("Use Cases must be distinct.");
            });

        }
    }
}
