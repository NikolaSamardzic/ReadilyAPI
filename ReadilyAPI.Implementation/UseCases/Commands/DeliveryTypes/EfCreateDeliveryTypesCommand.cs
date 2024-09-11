using FluentValidation;
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
    public class EfCreateDeliveryTypesCommand : EfUseCase, ICreateDeliveryTypeCommand
    {
        private readonly CreateDeliveryTypeValidator _validator;

        public EfCreateDeliveryTypesCommand(ReadilyContext context, CreateDeliveryTypeValidator validator) : base(context)
        {
            _validator = validator;
        }

        private EfCreateDeliveryTypesCommand() { }

        public int Id => 24;

        public string Name => "Create Delivery Type";

        public void Execute(CreateDeliveryTypeDto data)
        {
            _validator.ValidateAndThrow(data);

            Context.DeliveryTypes.Add(new Domain.DeliveryType
            {
                Name = data.Name,
            });

            Context.SaveChanges();
        }
    }
}
