using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Roles;
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
    public class EfGetRolesQuery : EfUseCase, IGetRolesQuery
    {
        public EfGetRolesQuery(ReadilyContext context) : base(context)
        {
        }

        private EfGetRolesQuery() { }

        public int Id => 11;

        public string Name => "Get Roles";

        public PagedResponse<RoleDto> Execute(RoleSearch search)
        {
            var query = Context.Roles
                .Include(x=>x.RoleUseCases)
                .Where(x => x.IsActive == search.IsActive)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.Name.Contains(search.Name));
            }

            var totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<RoleDto> {
                CurrentPage = page,
                Items = query.Select(x=> new RoleDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    RoleUseCases = x.RoleUseCases.Select(x=> x.UseCaseId)
                }).ToList(),
                ItemsPerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
