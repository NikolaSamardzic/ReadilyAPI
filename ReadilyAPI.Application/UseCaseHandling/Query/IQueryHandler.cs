using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ReadilyAPI.Application.UseCases;

namespace ReadilyAPI.Application.UseCaseHandling.Query
{
    public interface IQueryHandler
    {
        TResult HandleQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
            where TResult : class;
    }
}
