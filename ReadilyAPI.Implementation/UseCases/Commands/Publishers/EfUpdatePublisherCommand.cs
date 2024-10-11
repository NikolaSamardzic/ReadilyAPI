using AutoMapper;
using FluentValidation;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Publishers;
using ReadilyAPI.Application.UseCases.DTO.Publisher;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Implementation.Validators.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Publishers
{
    public class EfUpdatePublisherCommand : EfUseCase, IUpdatePublisherCommand
    {
        private readonly UpdatePublisherValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdatePublisherCommand(ReadilyContext context, UpdatePublisherValidator validator, IMapper mapper) : base(context)
        {
            _validator = validator;
            this._mapper = mapper;
        }

        private EfUpdatePublisherCommand() { }

        public int Id => 14;

        public string Name => "Update Publisher";

        public void Execute(UpdatePublisherDto data)
        {
            _validator.ValidateAndThrow(data);

            var publisher = Context.Publishers.FirstOrDefault(x=>x.Id == data.Id && x.IsActive);

            if(publisher == null) {
                throw new EntityNotFoundException(data.Id, nameof(Domain.Publisher));
            }

            _mapper.Map(data, publisher);

            Context.Publishers.Update(publisher);

            Context.SaveChanges();
        }
    }
}
