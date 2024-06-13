using ReadilyAPI.Application.UseCases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ReadilyAPI.Application.UseCaseHandling.Command
{
    public class TimeTrackingCommandHandler : ICommandHandler
    {
        private ICommandHandler _next;

        public TimeTrackingCommandHandler(ICommandHandler next)
        {
            _next = next;
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            _next.HandleCommand(command, data);

            stopwatch.Stop();

            Console.WriteLine($"UseCase: {command.Name}, Time: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
