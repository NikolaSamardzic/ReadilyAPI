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
    public abstract class EfDeleteUseCase<TEntity> : EfUseCase, ICommand<int>
        where TEntity : Entity
    {
        public abstract int Id { get; }
        public abstract string Name { get; }

        protected EfDeleteUseCase(ReadilyContext context) : base(context) { }

        protected EfDeleteUseCase() { }

        protected virtual IQueryable<TEntity> IncludeRelatedEntities(IQueryable<TEntity> query)
        {
            return query;
        }

        protected virtual void BeforeDelete(TEntity entity) { }

        protected virtual bool IsHardDelete() => false;

        public void Execute(int id)
        {
            var query = Context.Set<TEntity>().AsQueryable();
            query = IncludeRelatedEntities(query);

            var entity = query.FirstOrDefault(x => x.Id == id && x.IsActive);

            if (entity == null)
            {
                throw new EntityNotFoundException(id, nameof(TEntity));
            }

            BeforeDelete(entity);

            if (IsHardDelete())
            {
                Context.Set<TEntity>().Remove(entity);
            }
            else
            {
                entity.IsActive = false;
            }

            Context.SaveChanges();
        }
    }
}
