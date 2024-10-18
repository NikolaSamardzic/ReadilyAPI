using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO.Address;
using ReadilyAPI.Application.UseCases.DTO.Biography;
using ReadilyAPI.Application.UseCases.DTO.User;
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
    public class EfFindUserProfileQuery : EfFindUseCase<UserDto, User>, IUserProfileQuery
    {
        public EfFindUserProfileQuery(ReadilyContext context, IMapper mapper) : base(context, mapper)
        {
        }

        private EfFindUserProfileQuery() { }

        public override int Id => 38;

        public override string Name => "Find User Profile";

        protected override IQueryable<User> IncludeRelatedEntities(IQueryable<User> query)
        {
            return query
                .Include(x => x.Role)
                .Include(x => x.Address)
                .Include(x => x.Biography)
                .Include(x => x.Avatar);
        }
    }
}
