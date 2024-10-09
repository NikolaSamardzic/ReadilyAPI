using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Address;
using ReadilyAPI.Application.UseCases.DTO.Biography;
using ReadilyAPI.Application.UseCases.DTO.User;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        private readonly IMapper _mapper;

        public EfGetUsersQuery(ReadilyContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        private EfGetUsersQuery() { }

        public int Id => 39;

        public string Name => "Get Users";

        public PagedResponse<UserDto> Execute(UserSearch search)
        {
            var query = Context.Users
                .Include(x => x.Avatar)
                .Include(x => x.Address)
                .Include(x => x.Biography)
                .Include(x => x.Role)
                .Where(x=> x.IsBanned == search.IsBanned && x.IsActive == search.IsActive)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query
                    .Where(x =>
                            x.FirstName.Contains(search.Keyword) ||
                            x.LastName.Contains(search.Keyword) ||
                            x.Username.Contains(search.Keyword) ||
                            x.Email.Contains(search.Keyword)
                    );
            }

            if(search.RoleId.HasValue)
            {
                query = query.Where(x => x.RoleId == search.RoleId);
            }

            var totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            var users = query.ToList();

            return new PagedResponse<UserDto>() {
                CurrentPage = page,
                ItemsPerPage = perPage,
                TotalCount = totalCount,
                Items = _mapper.Map<IEnumerable<UserDto>>(users)
            };
        }
    }
}
