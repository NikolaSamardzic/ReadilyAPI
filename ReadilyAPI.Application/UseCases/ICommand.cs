using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases
{
    public interface ICommand<TData> : IUseCase
    {
        void Execute(TData data);
    }
}
