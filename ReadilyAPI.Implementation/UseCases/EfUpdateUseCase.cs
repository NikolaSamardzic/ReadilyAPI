using AutoMapper;
using FluentValidation;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases
{
    public abstract class EfUpdateUseCase<DtoEntity, TEntity> : EfUseCase, ICommand<DtoEntity>
        where DtoEntity : UpdateDto
        where TEntity : Entity
    {
        private readonly IMapper _mapper;
        private readonly AbstractValidator<DtoEntity> _validator;

        protected EfUpdateUseCase(ReadilyContext context, IMapper mapper, AbstractValidator<DtoEntity> validator) : base(context)
        {
            _mapper = mapper;
            _validator = validator;
        }

        protected EfUpdateUseCase() { }

        public abstract int Id { get; }

        public abstract string Name { get; }

        protected virtual IQueryable<TEntity> IncludeRelatedEntities(IQueryable<TEntity> query)
        {
            return query;
        }

        protected virtual void BeforeUpdate(DtoEntity dto, TEntity entity) { }

        public void Execute(DtoEntity data)
        {
            _validator.ValidateAndThrow(data);

            var query = Context.Set<TEntity>().AsQueryable();

            query = IncludeRelatedEntities(query);

            var item = query.SingleOrDefault(x => x.Id == data.Id);

            if (item == null)
            {
                throw new EntityNotFoundException(data.Id, nameof(TEntity));
            }

            BeforeUpdate(data, item);

            _mapper.Map(data, item);

            Context.Set<TEntity>().Update(item);

            Context.SaveChanges();
        }
    }
}
