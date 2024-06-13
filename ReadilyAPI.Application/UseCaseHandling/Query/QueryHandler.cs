using System;
using System.Collections.Generic;
using System.Text;
using ReadilyAPI.Application.UseCases;

namespace ReadilyAPI.Application.UseCaseHandling.Query
{
    public class QueryHandler : IQueryHandler
    {
        public TResult HandleQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
            where TResult : class
        {
            return query.Execute(search);
        }
    }
}
