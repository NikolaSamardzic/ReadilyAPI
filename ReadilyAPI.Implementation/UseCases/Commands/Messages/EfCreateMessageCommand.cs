using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application;
using ReadilyAPI.Application.Notification;
using ReadilyAPI.Application.UseCases.Commands.Messages;
using ReadilyAPI.Application.UseCases.DTO.Messages;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Implementation.Validators.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Messages
{
    public class EfCreateMessageCommand : EfUseCase, ICreateMessageCommand
    {
        private readonly IApplicationActor _actor;
        private readonly CreateMessageValidator _validator;
        private readonly IEmailService _emailService;

        public EfCreateMessageCommand(ReadilyContext context, IApplicationActor actor, CreateMessageValidator validator, IEmailService emailService) : base(context)
        {
            _actor = actor;
            _validator = validator;
            _emailService = emailService;
        }

        private EfCreateMessageCommand() { }

        public int Id => 58;

        public string Name => "Create Message";

        public void Execute(CreateMessageDto data)
        {
            _validator.ValidateAndThrow(data);

            var admins = Context
                .Users
                .Include(x => x.Role)
                .Where(x => x.Role.Name.ToLower().Equals("admin"))
                .ToList();

            foreach ( var admin in admins )
            {
                _emailService.SendEmailAsync(admin.Email, data.Subject, data.Message);
            }

            var message = new Domain.Message
            {
                Subject = data.Subject,
                Text = data.Message,
                UserId = _actor.Id,
            };

            Context.Messages.Add(message);

            Context.SaveChanges();
        }
    }
}
