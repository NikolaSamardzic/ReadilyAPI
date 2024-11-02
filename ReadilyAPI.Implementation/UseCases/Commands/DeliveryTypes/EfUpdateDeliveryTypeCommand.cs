using AutoMapper;
using FluentValidation;
using ReadilyAPI.Application.Exceptions;
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
    public class EfUpdateDeliveryTypeCommand : EfUpdateUseCase<UpdateDeliveryTypeDto, DeliveryType>, IUpdateDeliveryTypeCommand
    {
        public EfUpdateDeliveryTypeCommand(ReadilyContext context, UpdateDeliveryTypeValidator validator, IMapper mapper) : base(context, mapper, validator)
        {
        }

        private EfUpdateDeliveryTypeCommand() { }

        public override int Id => 26;

        public override string Name => "Update Delivery Type";

        protected override IQueryable<DeliveryType> IncludeRelatedEntities(IQueryable<DeliveryType> query)
        {
            return query.Where(x => x.IsActive);
        }
    }
}
