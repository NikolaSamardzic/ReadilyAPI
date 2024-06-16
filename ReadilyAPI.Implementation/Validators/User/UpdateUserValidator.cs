using FluentValidation;
using ReadilyAPI.Application;
using ReadilyAPI.Application.UseCases.DTO.User;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Validators.User
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        private readonly IApplicationActor _actor;
        private readonly ReadilyContext _context;

        public UpdateUserValidator(IApplicationActor actor, ReadilyContext context)
        {
            _actor = actor;
            _context = context;


            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Username)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9.šđžćčČĆŠĐŽ()\\/\\-_]{5,}$")
                .WithMessage("Your username must be at least 5 characters long and can only contain letters, numbers, periods, parentheses, forward slashes, hyphens, and underscores.")
                .Must(x => !_context.Users.Any(u => u.Username == x))
                .WithMessage("Username is already in use.");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .Matches("^[A-ZŠĐĆČŽ][a-zšđčćž]{2,}( [A-ZŠĐĆČŽ][a-zšđčćž]{2,})*$")
                .WithMessage("Incorrect format for first name (ex. Joe)");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .Matches("^[A-ZŠĐĆČŽ][a-zšđčćž]{2,}( [A-ZŠĐĆČŽ][a-zšđčćž]{2,})*$")
                .WithMessage("Incorrect format for last name (ex. Smith)");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .Matches("^\\d{5,15}$")
                .WithMessage("Incorrect format for phone (ex. 0611234567)");

            When(x => !string.IsNullOrEmpty(x.Avatar), () =>
            {
                RuleFor(x => x.Avatar).Must((x, fileName) =>
                {
                    var path = Path.Combine("wwwroot", "temp", fileName);

                    var exists = Path.Exists(path);

                    return exists;
                }).WithMessage("File doesn't exist.");
            });

            When(x => x.Address != null, () =>
            {
                RuleFor(x => x.Address.AddressName)
                    .NotEmpty()
                    .Matches("^[a-zšđžćčA-ZŠĐŽĆČ0-9\\s.\\-#\\/,]+$")
                    .WithMessage("Please enter a valid address name.");

                RuleFor(x => x.Address.AddressNumber)
                    .NotEmpty()
                    .Matches("^\\d+[a-zA-Z]?$")
                    .WithMessage("Please enter a valid address number.");

                RuleFor(x => x.Address.City)
                    .NotEmpty()
                    .Matches("^([A-ZŠĐŽĆČ][a-zšđžćč]{2,}\\s?)+$")
                    .WithMessage("Incorrect format for city (ex.  Los Angeles)");

                RuleFor(x => x.Address.State)
                    .NotEmpty()
                    .Matches("^([A-ZŠĐČĆŽ][a-zšđčćž]{2,}\\s?)+$")
                    .WithMessage("Incorrect format for state (ex.  California)");

                RuleFor(x => x.Address.PostalCode)
                    .NotEmpty()
                    .MinimumLength(5)
                    .MaximumLength(15)
                    .WithMessage("Incorrect format for zip code (ex.  90001)");

                RuleFor(x => x.Address.Country)
                    .NotEmpty()
                    .Matches("^([A-ZŠĐČĆŽ][a-zšđčćž]{2,}\\s?)+$")
                    .WithMessage("Incorrect format for country (ex.  United States)");

            });

            When(x => _context.Users.Find(_actor.Id).Role.Name == "Writer", () =>
            {
                RuleFor(x => x.Biography)
                                .NotNull()
                                .WithMessage("Biography is required for writers.")
                                .DependentRules(() =>
                                {
                                    RuleFor(x => x.Biography.Text)
                                        .NotEmpty()
                                        .WithMessage("Biography text is required.")
                                        .Matches("(\\s.*){4,}")
                                        .WithMessage("There must be at least 5 words in your biography.");
                                });
            });
        }


    }
}
