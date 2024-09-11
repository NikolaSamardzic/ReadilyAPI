using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Reviews;
using ReadilyAPI.Application.UseCases.DTO.Review;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Implementation.Validators.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Reviews
{
    public class EfUpdateReviewCommand : EfUseCase, IUpdateReviewCommand
    {
        private readonly IApplicationActor _actor;
        private readonly UpdateReviewValidator _validator;

        public EfUpdateReviewCommand(ReadilyContext context, IApplicationActor actor, UpdateReviewValidator validator) : base(context)
        {
            _actor = actor;
            _validator = validator;
        }

        private EfUpdateReviewCommand() { }

        public int Id => 52;

        public string Name => "Update Review";

        public void Execute(UpdateReviewDto data)
        {
            _validator.ValidateAndThrow(data);

            if (!Context
                .Users
                .Include(x => x.Reviews)
                .First(x => x.Id == _actor.Id)
                .Reviews
                .Any(r => r.Id == data.Id)) 
            {
                throw new ConflictException("Review doesn't belong to this user.");
            }

            var review = Context.Reviews.Find(data.Id);

            review.Stars = data.Stars;

            Context.SaveChanges();
        }
    }
}
