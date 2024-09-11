using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Messages
{
    public class CreateMessageDto
    {
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
