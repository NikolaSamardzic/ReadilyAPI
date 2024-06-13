using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReadilyAPI.Application.UseCaseHandling.Query
{
    public class AuthorizationQueryHandler : IQueryHandler
    {
        private IApplicationActor _actor;
        private IQueryHandler _next;

        public AuthorizationQueryHandler(IApplicationActor actor, IQueryHandler next)
        {
            _actor = actor;
            _next = next;
        }

        public TResult HandleQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search) where TResult : class
        {
            if (!_actor.AllowedUseCases.Contains(query.Id))
            {
                throw new UnauthorizedException(_actor.Username, query.Name);
            }

            return _next.HandleQuery(query, search);
        }
    }
}
