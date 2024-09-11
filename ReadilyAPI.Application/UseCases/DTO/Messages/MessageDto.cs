using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Messages
{
    public class MessageDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string CreatedAt { get; set; }
    }
}
