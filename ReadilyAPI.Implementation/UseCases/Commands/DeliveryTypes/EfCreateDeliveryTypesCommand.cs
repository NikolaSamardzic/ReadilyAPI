using AutoMapper;
using FluentValidation;
using ReadilyAPI.Application.UseCases.Commands.DeliveryTypes;
using ReadilyAPI.Application.UseCases.DTO.DeliveryType;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Validators.DeliveryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.DeliveryTypes
{
    public class EfCreateDeliveryTypesCommand : EfCreateUseCase<CreateDeliveryTypeDto, DeliveryType>, ICreateDeliveryTypeCommand
    {
        public EfCreateDeliveryTypesCommand(ReadilyContext context, CreateDeliveryTypeValidator validator, IMapper mapper) : base(context, mapper, validator)
        {
        }

        private EfCreateDeliveryTypesCommand() { }

        public override int Id => 24;

        public override string Name => "Create Delivery Type";
    }
}
