using ReadilyAPI.Application.UseCases.DTO.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Commands.Messages
{
    public interface ICreateMessageCommand : ICommand<CreateMessageDto>
    {
    }
}
