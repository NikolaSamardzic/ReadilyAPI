using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Publishers;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Publishers
{
    public class EfDeletePublisherCommand : EfUseCase, IDeletePublisherCommand
    {
        public EfDeletePublisherCommand(ReadilyContext context) : base(context)
        {
        }

        public int Id => 15;

        public string Name => "Delete Publisher";

        public void Execute(int data)
        {
            var publisher = Context.Publishers.Include(x=>x.Books).FirstOrDefault(x=>x.Id == data);

            if(publisher == null)
            {
                throw new EntityNotFoundException(data, nameof(Domain.Publisher));
            }

            if(publisher.Books.Any())
            {
                throw new EntityReferencedException(data, nameof(Domain.Publisher));
            }

            publisher.IsActive = false;

            Context.SaveChanges();
        }
    }
}
