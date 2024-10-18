using ReadilyAPI.Application;
using ReadilyAPI.Application.UseCases.Commands.Books;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadilyAPI.Domain;

namespace ReadilyAPI.Implementation.UseCases.Commands.Books
{
    public class EfActivateBookCommand : EfActivateUseCase<Book>, IActivateBookCommand
    {
        private readonly IApplicationActor _actor;

        public EfActivateBookCommand(ReadilyContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        private EfActivateBookCommand() { }

        public override int Id => 48;

        public override string Name => "Activate Book Command";

        protected override void BeforeActivate(Book entity)
        {
            if (entity.AuthorId != _actor.Id)
            {
                throw new ConflictException("Book doesn't belong to this author");
            }
        }
    }
}
