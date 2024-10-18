using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Address;
using ReadilyAPI.Application.UseCases.DTO.Biography;
using ReadilyAPI.Application.UseCases.DTO.User;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Extensions;
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
            return Context.Users
                .Include(x => x.Avatar)
                .Include(x => x.Address)
                .Include(x => x.Biography)
                .Include(x => x.Role)
                .Where(x => x.IsBanned == search.IsBanned && x.IsActive == search.IsActive)
                .WhereIf(!string.IsNullOrEmpty(search.Keyword),
                x =>
                            x.FirstName.Contains(search.Keyword) ||
                            x.LastName.Contains(search.Keyword) ||
                            x.Username.Contains(search.Keyword) ||
                            x.Email.Contains(search.Keyword)
                    )
                .WhereIf(search.RoleId.HasValue, x => x.RoleId == search.RoleId).AsPagedReponse<User, UserDto>(search, _mapper);
        }
    }
}
