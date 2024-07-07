using FluentValidation;
using ReadilyAPI.Application;
using ReadilyAPI.Application.UseCases.Commands.Reviews;
using ReadilyAPI.Application.UseCases.DTO.Review;
using ReadilyAPI.DataAccess;
using ReadilyAPI.DataAccess.Migrations;
using ReadilyAPI.Implementation.Validators.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Reviews
{
    public class EfCreateReviewCommand : EfUseCase, ICreateReviewCommand
    {
        private readonly CreateReviewValidator _validator;
        private readonly IApplicationActor _actor;

        public EfCreateReviewCommand(ReadilyContext context, CreateReviewValidator validator, IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 51;

        public string Name => "Create Review";

        public void Execute(CreateReviewDto data)
        {
            _validator.ValidateAndThrow(data);

            Context.Reviews.Add(new Domain.Review
            {
                BookId = data.BookId,
                UserId = _actor.Id,
                Stars = data.Stars,
            });

            Context.SaveChanges();
        }
    }
}
