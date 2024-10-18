using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Roles;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReadilyAPI.Implementation.UseCases.Commands.Roles
{
    public class EfDeleteRoleCommand : EfDeleteUseCase<Role>, IDeleteRoleCommand
    {
        public EfDeleteRoleCommand(ReadilyContext context) : base(context)
        {
        }

        private EfDeleteRoleCommand() { }

        public override int Id => 9;

        public override string Name => "Delete Role";

        protected override IQueryable<Role> IncludeRelatedEntities(IQueryable<Role> query)
        {
            return query
                .Include(x => x.RoleUseCases)
                .Include(x => x.Users);
        }

        protected override void BeforeDelete(Role entity)
        {
            if (entity.Users.Any())
            {
                throw new EntityReferencedException(entity.Id, nameof(Domain.Role));
            }
        }
    }
}
