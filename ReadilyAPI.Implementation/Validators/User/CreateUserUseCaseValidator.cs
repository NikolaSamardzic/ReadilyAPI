using FluentValidation;
using ReadilyAPI.Application.UseCases.DTO.User;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Implementation.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Validators.User
{
    public class CreateUserUseCaseValidator : AbstractValidator<CreateUserUseCaseDto>
    {
        private readonly ReadilyContext _context;

        public CreateUserUseCaseValidator(ReadilyContext context)
        {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.UserId)
                .NotEmpty()
                .Must(x => _context.Users.Any(u => u.Id == x))
                .WithMessage("User doesn't exist");

            RuleFor(x => x.UserUseCases)
                .NotEmpty()
                .Must(x => x.Max(x => x.UseCaseId) <= UseCaseInfo.MaxUseCaseId)
                .WithMessage("Use case doesn't exist");
        }
    }
}
