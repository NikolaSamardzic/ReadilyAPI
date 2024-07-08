using FluentValidation;
using ReadilyAPI.Application.UseCases.DTO.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Validators.Message
{
    public class CreateMessageValidator : AbstractValidator<CreateMessageDto>
    {
        public CreateMessageValidator() 
        {
            RuleFor(x => x.Subject).NotEmpty().MinimumLength(5);

            RuleFor(x => x.Message).NotEmpty().MinimumLength(5);
        }
    }
}
