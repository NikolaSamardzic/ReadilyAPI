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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReadilyAPI.Implementation.UseCases.Commands.Books
{
    public class EfDeleteBookCommand : EfDeleteUseCase<Book>, IDeleteBookCommand
    {
        private readonly IApplicationActor _actor;

        public EfDeleteBookCommand(ReadilyContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        private EfDeleteBookCommand() { }

        public override int Id => 47;

        public override string Name => "Delete Book Use Case";

        protected override void BeforeDelete(Book entity)
        {
            if (entity.AuthorId != _actor.Id)
            {
                throw new ConflictException("Book doesn't belong to this author.");
            }

            var orders = Context.Orders
            .Include(x => x.BookOrders)
                .Where(x => x.FinishedAt == null && x.BookOrders.Any(bo => bo.BookId == entity.Id)).ToList();

            foreach (var order in orders)
            {
                var bookOrder = order.BookOrders.First(x => x.BookId == entity.Id);

                Context.BooksOrders.Remove(bookOrder);

                order.TotalPrice = order.BookOrders.Sum(x => (decimal)x.Book.Price * x.Quantity);
            }
        }
    }
}
