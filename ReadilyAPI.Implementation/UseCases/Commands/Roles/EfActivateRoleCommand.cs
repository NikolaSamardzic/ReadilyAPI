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
    public class EfActivateRoleCommand : EfUseCase, IActivateRoleCommand
    {
        public EfActivateRoleCommand(ReadilyContext context) : base(context)
        {
        }

        private EfActivateRoleCommand() { }

        public int Id => 12;

        public string Name => "Activate Role";

        public void Execute(int data)
        {

            var role = Context.Roles.FirstOrDefault(x=> x.Id == data);

            if(role == null)
            {
                throw new EntityNotFoundException(data, nameof(Domain.Role));
            }

            role.IsActive = true;

            Context.SaveChanges();
        }
    }
}
