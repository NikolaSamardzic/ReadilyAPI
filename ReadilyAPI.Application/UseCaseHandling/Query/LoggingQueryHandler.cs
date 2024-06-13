using ReadilyAPI.Application.Logging;
using ReadilyAPI.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCaseHandling.Query
{
    public class LoggingQueryHandler : IQueryHandler
    {
        private IQueryHandler _next;
        private IApplicationActor _actor;
        private IUseCaseLogger _logger;

        public LoggingQueryHandler(IQueryHandler next, IApplicationActor actor, IUseCaseLogger logger)
        {
            _next = next;
            _actor = actor;
            _logger = logger;
        }

        public TResult HandleQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
            where TResult : class
        {
            _logger.Add(new UseCaseLogEntry
            {
                Actor = _actor.Username,
                ActorId = _actor.Id,
                Data = search,
                UseCaseName = query.Name,
            });

            return _next.HandleQuery(query, search);
        }
    }
}
