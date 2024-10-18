using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfFindCategoryQuery : EfFindUseCase<CategoryDto, Category>, IFindCategoryQuery
    {
        public EfFindCategoryQuery(ReadilyContext context, IMapper mapper) : base(context, mapper)
        {
        }

        private EfFindCategoryQuery() { }

        public override int Id => 5;

        public override string Name => "Find Category";

        protected override IQueryable<Category> IncludeRelatedEntities(IQueryable<Category> query)
        {
            return query
                    .Include(x => x.Parent)
                    .Include(x => x.Children)
                    .Include(x => x.Image);
        }
    }
}
