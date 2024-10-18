using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Users;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Users
{
    public class EfActivateUserCommand : EfActivateUseCase<User>, IActivateUserCommand
    {
        public EfActivateUserCommand(ReadilyContext context) : base(context)
        {
        }

        private EfActivateUserCommand() { }

        public override int Id => 42;

        public override string Name => "Activate User";
    }
}
