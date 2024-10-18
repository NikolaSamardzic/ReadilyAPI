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
    public class EfActivateRoleCommand : EfActivateUseCase<Role>, IActivateRoleCommand
    {
        public EfActivateRoleCommand(ReadilyContext context) : base(context)
        {
        }

        private EfActivateRoleCommand() { }

        public override int Id => 12;

        public override string Name => "Activate Role";
    }
}
