using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Books;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Books
{
    public class EfDeleteBookCommand : EfUseCase, IDeleteBookCommand
    {
        private readonly IApplicationActor _actor;

        public EfDeleteBookCommand(ReadilyContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 47;

        public string Name => "Delete Book Use Case";

        public void Execute(int data)
        {
            var book = Context.Books.FirstOrDefault(x => x.Id == data && x.IsActive);

            if (book == null)
            {
                throw new EntityNotFoundException(data, nameof(Book));
            }

            if(book.AuthorId != _actor.Id)
            {
                throw new ConflictException("Book doesn't belong to this author.");
            }

            book.IsActive = false;

            var orders = Context.Orders
                .Include(x => x.BookOrders)
                .Where(x => x.FinishedAt == null && x.BookOrders.Any(bo => bo.BookId == data)).ToList();

            foreach(var order in orders)
            {
                var bookOrder = order.BookOrders.First(x=> x.BookId == data);

                Context.BooksOrders.Remove(bookOrder);

                order.TotalPrice = order.BookOrders.Sum(x => (decimal)x.Book.Price * x.Quantity);
            }

            Context.SaveChanges();
        }
    }
}
