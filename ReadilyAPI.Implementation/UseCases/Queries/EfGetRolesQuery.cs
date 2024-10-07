using AutoMapper;
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
        private readonly IMapper _mapper;

        public EfGetRolesQuery(ReadilyContext context, IMapper mapper) : base(context)
        {
            this._mapper = mapper;
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

            var result = query.Skip(skip).Take(perPage).ToList();

            return new PagedResponse<RoleDto> {
                CurrentPage = page,
                Items = _mapper.Map<IEnumerable<RoleDto>>(result),
                ItemsPerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
