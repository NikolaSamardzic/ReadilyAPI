using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Application.Notification
{
    public interface IEmailService
    {
        void SendEmailAsync(string to, string subject, string body);
    }
}
