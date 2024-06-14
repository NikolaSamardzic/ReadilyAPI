using ReadilyAPI.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases
{
    public static class UseCaseInfo
    {
        public static IEnumerable<int> AllUseCases
        {
            get
            {
                var type = typeof(IUseCase);
                var types = typeof(UseCaseInfo).Assembly.GetTypes();
                return null;
            }
        }

        public static int MaxUseCaseId => 20;
    }
}
