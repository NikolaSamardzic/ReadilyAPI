using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Roles;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Roles
{
    public class EfDeleteRoleCommand : EfUseCase, IDeleteRoleCommand
    {
        public EfDeleteRoleCommand(ReadilyContext context) : base(context)
        {
        }

        public int Id => 9;

        public string Name => "Delete Role";

        public void Execute(int data)
        {
            var role = Context.Roles
                .Include(x => x.RoleUseCases)
                .Include(x => x.Users)
                .FirstOrDefault(x => x.Id == data && x.IsActive);

            if (role == null)
            {
                throw new EntityNotFoundException(data, nameof(Domain.Role));
            }

            if (role.Users.Any())
            {
                throw new EntityReferencedException(data, nameof(Domain.Role));
            }

            role.IsActive = false;

            Context.SaveChanges();
        }
    }
}
