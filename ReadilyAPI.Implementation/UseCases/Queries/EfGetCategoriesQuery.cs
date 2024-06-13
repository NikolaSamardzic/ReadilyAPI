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
        public EfGetCategoriesQuery(ReadilyContext context) : base(context)
        {
        }

        public int Id => 6;

        public string Name => "Get Categories";

        public PagedResponse<CategoryDto> Execute(CategorySearch search)
        {
            var query = Context.Categories
                .Include(x=>x.Parent)
                
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

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<CategoryDto> {
                CurrentPage = page,
                Items = query
                .Where(x=>x.ParentId == null)
                .Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ParentId = x.ParentId,
                    Children = x.Children.Select(c => new CategoryDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        ParentId = c.ParentId,
                        Children = new List<CategoryDto>() { }
                    })
                }).ToList(),
                ItemsPerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
