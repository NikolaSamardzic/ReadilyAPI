using ReadilyAPI.Application;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Users;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Implementation.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Users
{
    public class EfVerifyUserCommand : EfUseCase, IVerifyUserCommand
    {
        public EfVerifyUserCommand(ReadilyContext context) : base(context)
        {
        }

        private EfVerifyUserCommand() { }

        public int Id => 35;

        public string Name => "Verify User";

        public void Execute(string data)
        {
            var user = Context.Users.FirstOrDefault(x => x.Token == data);

            if (user == null)
            {
                throw new EntityNotFoundException(data, nameof(Domain.User));
            }
            user.EmailVerifiedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
