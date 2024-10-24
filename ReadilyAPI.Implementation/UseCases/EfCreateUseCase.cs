using AutoMapper;
using FluentValidation;
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
    public abstract class EfCreateUseCase<DtoEntity, TEntity> : EfUseCase, ICommand<DtoEntity>
        where DtoEntity : class
        where TEntity : class
    {
        private readonly IMapper _mapper;
        private readonly AbstractValidator<DtoEntity> _validator;

        protected EfCreateUseCase(ReadilyContext context, IMapper mapper, AbstractValidator<DtoEntity> validator) : base(context)
        {
            _mapper = mapper;
            _validator = validator;
        }

        protected EfCreateUseCase() { }

        public abstract int Id { get; }
        public abstract string Name { get; }

        protected virtual bool IsAddRange() => false;

        protected virtual void BeforeAdd(DtoEntity data) { }

        public void Execute(DtoEntity data)
        {
            _validator.Validate(data);

            BeforeAdd(data);

            if (IsAddRange()) 
            {
                Context.Set<TEntity>().AddRange(_mapper.Map<IEnumerable<TEntity>>(data));
            }
            else
            {
                Context.Set<TEntity>().Add(_mapper.Map<TEntity>(data));
            }

            Context.SaveChanges();
        }
    }
}
