using FluentValidation;
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
    public class EfCreatePublisherCommand : EfUseCase, ICreatePublisherCommand
    {
        private readonly CreatePublisherValidator _validator;

        public EfCreatePublisherCommand(ReadilyContext context, CreatePublisherValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 13;

        public string Name => "Create Publisher";

        public void Execute(CreatePublisherDto data)
        {
            _validator.ValidateAndThrow(data);

            Context.Publishers.Add(new Domain.Publisher
            {
                Name = data.Name,
            });

            Context.SaveChanges();
        }
    }
}
