using ReadilyAPI.Application;
using ReadilyAPI.Application.UseCases.Commands.Books;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Books
{
    public class EfActivateBookCommand : EfUseCase, IActivateBookCommand
    {
        private readonly IApplicationActor _actor;

        public EfActivateBookCommand(ReadilyContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 48;

        public string Name => "Activate Book Command";

        public void Execute(int data)
        {
            var book = Context.Books.FirstOrDefault(x => x.Id == data);

            if(book == null)
            {
                throw new EntityNotFoundException(data, nameof(Domain.Book));
            }

            if(book.AuthorId != _actor.Id)
            {
                throw new ConflictException("Book doesn't belong to this author");
            }

            book.IsActive = true;

            Context.SaveChanges();
        }
    }
}
