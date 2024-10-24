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
    public class EfCreatePublisherCommand : EfCreateUseCase<CreatePublisherDto, Publisher>, ICreatePublisherCommand
    {
        public EfCreatePublisherCommand(ReadilyContext context, CreatePublisherValidator validator, IMapper mapper) : base(context, mapper, validator)
        {
        }

        private EfCreatePublisherCommand() { }

        public override int Id => 13;

        public override string Name => "Create Publisher";
    }
}
