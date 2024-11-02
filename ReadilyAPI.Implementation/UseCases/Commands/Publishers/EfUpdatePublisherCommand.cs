using AutoMapper;
using FluentValidation;
using ReadilyAPI.Application.Exceptions;
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
    public class EfUpdatePublisherCommand : EfUpdateUseCase<UpdatePublisherDto, Publisher>, IUpdatePublisherCommand
    {
        public EfUpdatePublisherCommand(ReadilyContext context, UpdatePublisherValidator validator, IMapper mapper) : base(context, mapper, validator)
        {
        }

        private EfUpdatePublisherCommand() { }

        public override int Id => 14;

        public override string Name => "Update Publisher";
    }
}
