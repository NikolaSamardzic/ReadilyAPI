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
    public class EfUnBanUserCommand : EfUseCase, IUnBanUserCommand
    {
        public EfUnBanUserCommand(ReadilyContext context) : base(context)
        {
        }

        public int Id => 41;

        public string Name => "Unban User";

        public void Execute(int data)
        {
            var user = Context.Users.FirstOrDefault(x => x.Id == data);

            if (user == null)
            {
                throw new EntityNotFoundException(data, nameof(Domain.User));
            }

            user.IsBanned = false;

            Context.SaveChanges();
        }
    }
}
