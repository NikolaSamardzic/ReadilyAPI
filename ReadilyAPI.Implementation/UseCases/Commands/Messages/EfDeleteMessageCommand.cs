using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Comments;
using ReadilyAPI.Application.UseCases.Commands.Messages;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Messages
{
    public class EfDeleteMessageCommand : EfDeleteUseCase<Message>, IDeleteMessageCommand
    {
        public EfDeleteMessageCommand(ReadilyContext context) : base(context)
        {
        }

        private EfDeleteMessageCommand() { }

        public override int Id => 59;

        public override string Name => "Delete Message";
    }
}
