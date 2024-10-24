using AutoMapper;
using FluentValidation;
using ReadilyAPI.Application;
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
    public class EfCreateReviewCommand : EfCreateUseCase<CreateReviewDto, Review>, ICreateReviewCommand
    {
        private readonly IApplicationActor _actor;

        public EfCreateReviewCommand(ReadilyContext context, CreateReviewValidator validator, IApplicationActor actor, IMapper mapper) : base(context, mapper, validator)
        {
            _actor = actor;
        }

        private EfCreateReviewCommand() { }

        public override int Id => 51;

        public override string Name => "Create Review";

        protected override void BeforeAdd(CreateReviewDto data)
        {
            data.UserId = _actor.Id;
        }
    }
}
