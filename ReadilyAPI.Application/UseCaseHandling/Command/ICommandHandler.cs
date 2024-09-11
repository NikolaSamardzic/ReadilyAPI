using ReadilyAPI.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ReadilyAPI.Application.UseCaseHandling.Command
{
    public interface ICommandHandler
    {
        void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data);
    }
}
