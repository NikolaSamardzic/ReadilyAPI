using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application;
using ReadilyAPI.Application.Notification;
using ReadilyAPI.Application.UseCases.Commands.Messages;
using ReadilyAPI.Application.UseCases.DTO.Messages;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Validators.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Messages
{
    public class EfCreateMessageCommand : EfCreateUseCase<CreateMessageDto, Message>, ICreateMessageCommand
    {
        private readonly IApplicationActor _actor;
        private readonly IEmailService _emailService;

        public EfCreateMessageCommand(ReadilyContext context, IApplicationActor actor, CreateMessageValidator validator, IEmailService emailService, IMapper mapper) : base(context, mapper, validator)
        {
            _actor = actor;
            _emailService = emailService;
        }

        private EfCreateMessageCommand() { }

        public override int Id => 58;

        public override string Name => "Create Message";

        protected override void BeforeAdd(CreateMessageDto data)
        {
            data.UserId = _actor.Id;

            var admins = Context
                .Users
                .Include(x => x.Role)
                .Where(x => x.Role.Name.ToLower().Equals("admin"))
                .ToList();

            foreach (var admin in admins)
            {
                _emailService.SendEmailAsync(admin.Email, data.Subject, data.Message);
            }
        }
    }
}
