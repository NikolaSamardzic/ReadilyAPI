using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ReadilyAPI.Implementation.UseCases
{
    public abstract class EfActivateUseCase<TEntity> : EfUseCase, ICommand<int>
        where TEntity : Entity
    {
        protected EfActivateUseCase(ReadilyContext context) : base(context) { }

        protected EfActivateUseCase() { }

        public abstract int Id { get; }

        public abstract string Name { get; }

        protected virtual IQueryable<TEntity> IncludeRelatedEntities(IQueryable<TEntity> query)
        {
            return query;
        }

        protected virtual void BeforeActivate(TEntity entity) { }

        public void Execute(int data)
        {
            var query = Context.Set<TEntity>().AsQueryable();
            query = IncludeRelatedEntities(query);

            var entity = query.FirstOrDefault(x => x.Id == data);

            if (entity == null)
            {
                throw new EntityNotFoundException(data, nameof(TEntity));
            }

            BeforeActivate(entity);

            entity.IsActive = true;

            Context.SaveChanges();
        }
    }
}
