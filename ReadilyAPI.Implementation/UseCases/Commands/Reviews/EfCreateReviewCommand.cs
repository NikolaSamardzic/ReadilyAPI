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
    public class EfCreateReviewCommand : EfUseCase, ICreateReviewCommand
    {
        private readonly CreateReviewValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfCreateReviewCommand(ReadilyContext context, CreateReviewValidator validator, IApplicationActor actor, IMapper mapper) : base(context)
        {
            _validator = validator;
            _actor = actor;
            _mapper = mapper;
        }

        private EfCreateReviewCommand() { }

        public int Id => 51;

        public string Name => "Create Review";

        public void Execute(CreateReviewDto data)
        {
            _validator.ValidateAndThrow(data);

            data.UserId = _actor.Id;

            Context.Reviews.Add(_mapper.Map<Review>(data));

            Context.SaveChanges();
        }
    }
}
