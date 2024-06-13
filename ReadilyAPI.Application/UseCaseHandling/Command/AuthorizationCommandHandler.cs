using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReadilyAPI.Application.UseCaseHandling.Command
{
    public class AuthorizationCommandHandler : ICommandHandler
    {
        private IApplicationActor _actor;
        private ICommandHandler _next;

        public AuthorizationCommandHandler(IApplicationActor actor, ICommandHandler next)
        {
            _actor = actor;
            _next = next;
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            if (!_actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedException(_actor.Username, command.Name);
            }

            _next.HandleCommand(command, data);
        }
    }
}
