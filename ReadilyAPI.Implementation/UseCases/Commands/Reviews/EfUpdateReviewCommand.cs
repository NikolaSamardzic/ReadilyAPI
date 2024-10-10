using AutoMapper;
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
        private readonly IMapper _mapper;

        public EfUpdateReviewCommand(ReadilyContext context, IApplicationActor actor, UpdateReviewValidator validator, IMapper mapper) : base(context)
        {
            _actor = actor;
            _validator = validator;
            _mapper = mapper;
        }

        private EfUpdateReviewCommand() { }

        public int Id => 52;

        public string Name => "Update Review";

        public void Execute(UpdateReviewDto data)
        {
            _validator.ValidateAndThrow(data);

            var review = Context.Reviews.FirstOrDefault(x => x.Id == data.Id);

            if (review == null)
            {
                throw new EntityNotFoundException(data.Id, nameof(Domain.Review));
            }

            if (review.UserId != _actor.Id) 
            {
                throw new ConflictException("Review doesn't belong to this user.");
            }

            _mapper.Map(data, review);

            Context.SaveChanges();
        }
    }
}
