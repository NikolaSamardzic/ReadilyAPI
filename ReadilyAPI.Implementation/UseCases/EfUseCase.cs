using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected ReadilyContext Context { get; set; }

        protected EfUseCase(ReadilyContext context)
        {
            Context = context;
        }
    }
}
