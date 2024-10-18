using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.DTO.Roles;
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
    public class EfFindRoleQuery : EfFindUseCase<RoleDto, Role>, IFindRoleQuery
    {
        public EfFindRoleQuery(ReadilyContext context, IMapper mapper) : base(context, mapper)
        {
        }

        private EfFindRoleQuery() { }

        public override int Id => 10;

        public override string Name => "Find Role";

        protected override IQueryable<Role> IncludeRelatedEntities(IQueryable<Role> query)
        {
            return query
                .Include(x => x.RoleUseCases);
        }
    }
}
