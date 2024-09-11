using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases
{
    public interface IQuery<TSearch, TResult> : IUseCase
        where TResult : class
    {
        TResult Execute(TSearch search);
    }
}
