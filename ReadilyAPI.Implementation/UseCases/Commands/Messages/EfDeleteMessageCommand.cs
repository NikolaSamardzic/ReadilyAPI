using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Comments;
using ReadilyAPI.Application.UseCases.Commands.Messages;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Messages
{
    public class EfDeleteMessageCommand : EfUseCase, IDeleteMessageCommand
    {
        public EfDeleteMessageCommand(ReadilyContext context) : base(context)
        {
        }

        private EfDeleteMessageCommand() { }

        public int Id => 59;

        public string Name => "Delete Message";

        public void Execute(int data)
        {
            var message = Context.Messages.FirstOrDefault(x => x.Id == data);

            if(message == null) 
            {
                throw new EntityNotFoundException(data, nameof(Domain.Message));
            }

            message.IsActive = false;

            Context.SaveChanges();
        }
    }
}
