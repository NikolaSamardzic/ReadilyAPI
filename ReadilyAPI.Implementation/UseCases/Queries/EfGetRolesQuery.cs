using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Roles;
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
            return Context.Roles
                .Include(x => x.RoleUseCases)
                .Where(x => x.IsActive == search.IsActive)
                .WhereIf(!string.IsNullOrEmpty(search.Name), x => x.Name.Contains(search.Name))
                .AsPagedReponse<Role, RoleDto>(search, _mapper);
        }
    }
}
