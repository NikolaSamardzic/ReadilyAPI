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
    public class EfFindRoleQuery : EfUseCase, IFindRoleQuery
    {
        public EfFindRoleQuery(ReadilyContext context) : base(context)
        {
        }

        public int Id => 10;

        public string Name => "Find Role";

        public RoleDto Execute(int search)
        {
            var role = Context.Roles
                .Include(x=>x.RoleUseCases)
                .FirstOrDefault(x=> x.Id == search && x.IsActive);

            if (role == null)
            {
                throw new EntityNotFoundException(search, nameof(Domain.Role));
            }

            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                RoleUseCases = role.RoleUseCases.Select(x=> x.UseCaseId),
            };
        }
    }
}
