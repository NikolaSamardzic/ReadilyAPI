using Microsoft.Extensions.Options;
using ReadilyAPI.Application.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Notification
{
    public class MessageAdminEmailService : IEmailService
    {

        private readonly SmtpSettings _smtpSettings;

        public MessageAdminEmailService(SmtpSettings smtpSettings)
        {
            _smtpSettings = smtpSettings;
        }

        public void SendEmailAsync(string to, string subject, string body)
        {
            using (var client = new SmtpClient(_smtpSettings.Server, _smtpSettings.Port))
            {
                client.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
                client.EnableSsl = _smtpSettings.EnableSsl;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpSettings.SenderEmail, _smtpSettings.SenderName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(to);

                client.SendMailAsync(mailMessage);
            }
        }
    }
}
