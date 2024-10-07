using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;
using ReadilyAPI.DataAccess;
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
            var query = Context.Categories
                .Include(x=>x.Parent)
                .ThenInclude(x => x.Image)
                .Include(x => x.Image)
                .Where(x=>x.IsActive == search.IsActive)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x=>x.Name.Contains(search.Name));
            }

            if(search.ParentId.HasValue)
            {
                query = query.Where(x => x.ParentId == search.ParentId);
            }
            else
            {
                query = query.Include(x => x.Children);
            }

            var totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            var result = query.Skip(skip).Take(perPage).ToList();

            return new PagedResponse<CategoryDto>
            {
                CurrentPage = page,
                Items = _mapper.Map<IEnumerable<CategoryDto>>(result),
                ItemsPerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
