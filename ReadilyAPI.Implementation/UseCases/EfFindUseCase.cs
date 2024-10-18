using AutoMapper;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases
{
    public abstract class EfFindUseCase<TResult, TEntity> : EfUseCase, IQuery<int, TResult>
        where TResult : class
        where TEntity : Entity
    {
        private readonly IMapper _mapper;

        protected EfFindUseCase(ReadilyContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        protected EfFindUseCase() { }

        public abstract int Id { get; }
        public abstract string Name { get; }

        protected virtual IQueryable<TEntity> IncludeRelatedEntities(IQueryable<TEntity> query)
        {
            return query;
        }

        public TResult Execute(int search)
        {
            var query = Context.Set<TEntity>().AsQueryable();

            query = IncludeRelatedEntities(query);

            var item = query.Single(x => x.Id == search);

            if (item == null)
            {
                throw new EntityNotFoundException(search, nameof(TEntity));
            }

            return _mapper.Map<TResult>(item);
        }
    }
}
