using AutoMapper;
using FluentValidation;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.DeliveryTypes;
using ReadilyAPI.Application.UseCases.DTO.DeliveryType;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Implementation.Validators.DeliveryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.DeliveryTypes
{
    public class EfUpdateDeliveryTypeCommand : EfUseCase, IUpdateDeliveryTypeCommand
    {
        private readonly UpdateDeliveryTypeValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateDeliveryTypeCommand(ReadilyContext context, UpdateDeliveryTypeValidator validator, IMapper mapper) : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        private EfUpdateDeliveryTypeCommand() { }

        public int Id => 26;

        public string Name => "Update Delivery Type";

        public void Execute(UpdateDeliveryTypeDto data)
        {
            _validator.ValidateAndThrow(data);

            var deliveryType = Context.DeliveryTypes.FirstOrDefault(x => x.Id == data.Id && x.IsActive);

            if (deliveryType == null)
            {
                throw new EntityNotFoundException(data.Id, nameof(Domain.DeliveryType));
            }

            _mapper.Map(data, deliveryType);

            Context.SaveChanges();
        }
    }
}
