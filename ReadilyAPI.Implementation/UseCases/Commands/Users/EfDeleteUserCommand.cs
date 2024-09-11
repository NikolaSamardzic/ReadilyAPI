using ReadilyAPI.Application;
using ReadilyAPI.Application.UseCases.Commands.Users;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Users
{
    public class EfDeleteUserCommand : EfUseCase, IDeleteUserCommand
    {
        private readonly IApplicationActor _actor;

        public EfDeleteUserCommand(ReadilyContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        private EfDeleteUserCommand() { }

        public int Id => 36;

        public string Name => "Delete User";

        public void Execute(int data)
        {
            var user = Context.Users.Find(_actor.Id);
            user.IsActive = false;
            Context.SaveChanges();
        }
    }
}
