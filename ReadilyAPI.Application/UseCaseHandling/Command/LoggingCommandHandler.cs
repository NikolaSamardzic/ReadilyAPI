using ReadilyAPI.Application.Logging;
using ReadilyAPI.Application.UseCases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCaseHandling.Command
{
    public class LoggingCommandHandler : ICommandHandler
    {
        private ICommandHandler _next;
        private IApplicationActor _actor;
        private IUseCaseLogger _logger;

        public LoggingCommandHandler(ICommandHandler next, IApplicationActor actor, IUseCaseLogger logger)
        {
            _next = next;
            _actor = actor;
            _logger = logger;
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            _logger.Add(new UseCaseLogEntry
            {
                Actor = _actor.Username,
                ActorId = _actor.Id,
                Data = data,
                UseCaseName = command.Name,
            });

            _next.HandleCommand(command,data);
        }
    }
}
