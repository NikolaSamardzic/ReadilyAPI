using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.Logging;
using ReadilyAPI.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ReadilyAPI.Application.UseCaseHandling.Command
{
    public class CommandHandler : ICommandHandler
    {
        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            command.Execute(data);
        }
    }
}
