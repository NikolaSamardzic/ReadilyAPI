using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO.Address;
using ReadilyAPI.Application.UseCases.DTO.Biography;
using ReadilyAPI.Application.UseCases.DTO.User;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfFindUserProfileQuery : EfUseCase, IUserProfileQuery
    {
        private readonly IMapper _mapper;

        public EfFindUserProfileQuery(ReadilyContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        private EfFindUserProfileQuery() { }

        public int Id => 38;

        public string Name => "Find User Profile";

        public UserDto Execute(int search)
        {
            var user = Context.Users
                .Include(x => x.Role)
                .Include(x => x.Address)
                .Include(x => x.Biography)
                .Include(x => x.Avatar)
                .First(x => x.Id == search);

            return _mapper.Map<UserDto>(user);
        }
    }
}
