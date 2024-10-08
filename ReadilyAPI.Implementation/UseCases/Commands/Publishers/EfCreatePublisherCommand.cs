using AutoMapper;
using FluentValidation;
using ReadilyAPI.Application.UseCases.Commands.Publishers;
using ReadilyAPI.Application.UseCases.DTO.Publisher;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Validators.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Publishers
{
    public class EfCreatePublisherCommand : EfUseCase, ICreatePublisherCommand
    {
        private readonly CreatePublisherValidator _validator;
        private readonly IMapper _mapper;

        public EfCreatePublisherCommand(ReadilyContext context, CreatePublisherValidator validator, IMapper mapper) : base(context)
        {
            _validator = validator;
            this._mapper = mapper;
        }

        private EfCreatePublisherCommand() { }

        public int Id => 13;

        public string Name => "Create Publisher";

        public void Execute(CreatePublisherDto data)
        {
            _validator.ValidateAndThrow(data);

            Context.Publishers.Add(_mapper.Map<Publisher>(data));

            Context.SaveChanges();
        }
    }
}
