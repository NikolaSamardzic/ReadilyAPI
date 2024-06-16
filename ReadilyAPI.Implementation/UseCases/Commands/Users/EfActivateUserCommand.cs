using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Users;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Users
{
    public class EfActivateUserCommand : EfUseCase, IActivateUserCommand
    {
        public EfActivateUserCommand(ReadilyContext context) : base(context)
        {
        }

        public int Id => 42;

        public string Name => "Activate User";

        public void Execute(int data)
        {
            var user = Context.Users.FirstOrDefault(x => x.Id == data);

            if (user == null)
            {
                throw new EntityNotFoundException(data, nameof(Domain.User));
            }

            user.IsActive = true;

            Context.SaveChanges();
        }
    }
}
