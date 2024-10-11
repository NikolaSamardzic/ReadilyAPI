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
    public class EfCreateMessageCommand : EfUseCase, ICreateMessageCommand
    {
        private readonly IApplicationActor _actor;
        private readonly CreateMessageValidator _validator;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public EfCreateMessageCommand(ReadilyContext context, IApplicationActor actor, CreateMessageValidator validator, IEmailService emailService, IMapper mapper) : base(context)
        {
            _actor = actor;
            _validator = validator;
            _emailService = emailService;
            _mapper = mapper;
        }

        private EfCreateMessageCommand() { }

        public int Id => 58;

        public string Name => "Create Message";

        public void Execute(CreateMessageDto data)
        {
            _validator.ValidateAndThrow(data);

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

            Context.Messages.Add(_mapper.Map<Message>(data));

            Context.SaveChanges();
        }
    }
}
