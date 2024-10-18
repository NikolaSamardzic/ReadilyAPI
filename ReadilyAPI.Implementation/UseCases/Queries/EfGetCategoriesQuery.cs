using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfGetCategoriesQuery : EfUseCase, IGetCategoriesQuery
    {
        private readonly IMapper _mapper;

        public EfGetCategoriesQuery(ReadilyContext context, IMapper mapper) : base(context)
        {
            this._mapper = mapper;
        }

        private EfGetCategoriesQuery() { }

        public int Id => 6;

        public string Name => "Get Categories";

        public PagedResponse<CategoryDto> Execute(CategorySearch search)
        {
            return Context.Categories
                .Include(x => x.Parent)
                .ThenInclude(x => x.Image)
                .Include(x => x.Image)
                .IncludeIf(!search.ParentId.HasValue, x => x.Children)
                .Where(x => x.IsActive == search.IsActive)
                .WhereIf(!string.IsNullOrEmpty(search.Name), x => x.Name.Contains(search.Name))
                .WhereIf(search.ParentId.HasValue, x => x.ParentId == search.ParentId)
                .AsPagedReponse<Category, CategoryDto>(search, _mapper);
        }
    }
}
