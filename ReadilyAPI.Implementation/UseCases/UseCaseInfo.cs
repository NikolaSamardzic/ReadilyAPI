using ReadilyAPI.Application.UseCases;
using ReadilyAPI.Application.UseCases.DTO.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases
{
    public static class UseCaseInfo
    {
        public static IEnumerable<UseCaseDto> AllUseCases
        {
            get
            {
                var types = typeof(UseCaseInfo).Assembly.GetTypes()
                                .Where(p => typeof(IUseCase).IsAssignableFrom(p))
                                .Where(p => p.GetConstructor(BindingFlags.Instance
                                                             | BindingFlags.NonPublic,
                                                             null,
                                                             Type.EmptyTypes,
                                                             null) != null)
                                .Where(p => !p.IsInterface && !p.IsAbstract)
                                .Select(x => Activator.CreateInstance(x, true));

                List<UseCaseDto> result = new List<UseCaseDto>();

                foreach (IUseCase currentType in types)
                {
                    result.Add(new UseCaseDto { Id = currentType.Id, Name = currentType.Name.ToLower() });
                }

                return result;
            }
        }

        public static int MaxUseCaseId {
            get
            {
                var types = typeof(UseCaseInfo).Assembly.GetTypes()
                .Where(p => typeof(IUseCase).IsAssignableFrom(p))
                .Where(p => p.GetConstructor(BindingFlags.Instance
                                             | BindingFlags.NonPublic,
                                             null,
                                             Type.EmptyTypes,
                                             null) != null)
                .Where(p => !p.IsInterface && !p.IsAbstract)
                .Select(x => Activator.CreateInstance(x, true));

                List<UseCaseDto> result = new List<UseCaseDto>();

                foreach (IUseCase currentType in types)
                {
                    result.Add(new UseCaseDto { Id = currentType.Id, Name = currentType.Name.ToLower() });
                }

                return result.Max(x => x.Id);
            }
        }
    }
}
