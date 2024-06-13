using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ReadilyAPI.Application.UseCases;

namespace ReadilyAPI.Application.UseCaseHandling.Query
{
    public class TimeTrackingQueryHandler : IQueryHandler
    {
        private IQueryHandler _next;

        public TimeTrackingQueryHandler(IQueryHandler next)
        {
            _next = next;
        }

        public TResult HandleQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
            where TResult : class
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var result = _next.HandleQuery(query, search);

            stopwatch.Stop();

            Console.WriteLine($"UseCase: {query.Name}, Time: {stopwatch.ElapsedMilliseconds} ms");

            return result;
        }
    }
}
