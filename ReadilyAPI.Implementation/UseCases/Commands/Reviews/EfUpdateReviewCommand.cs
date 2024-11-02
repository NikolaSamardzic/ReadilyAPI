using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Reviews;
using ReadilyAPI.Application.UseCases.DTO.Review;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Validators.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Reviews
{
    public class EfUpdateReviewCommand : EfUpdateUseCase<UpdateReviewDto, Review>, IUpdateReviewCommand
    {
        private readonly IApplicationActor _actor;

        public EfUpdateReviewCommand(ReadilyContext context, IApplicationActor actor, UpdateReviewValidator validator, IMapper mapper) : base(context, mapper, validator)
        {
            _actor = actor;
        }

        private EfUpdateReviewCommand() { }

        public override int Id => 52;

        public override string Name => "Update Review";

        protected override void BeforeUpdate(UpdateReviewDto dto, Review entity)
        {
            if (entity.UserId != _actor.Id)
            {
                throw new ConflictException("Review doesn't belong to this user.");
            }
        }
    }
}
