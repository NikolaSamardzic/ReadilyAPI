using ReadilyAPI.Application;
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
    public class EfDeleteUserCommand : EfDeleteUseCase<User>, IDeleteUserCommand
    {
        public EfDeleteUserCommand(ReadilyContext context) : base(context)
        {
        }

        private EfDeleteUserCommand() { }

        public override int Id => 36;

        public override string Name => "Delete User";
    }
}
