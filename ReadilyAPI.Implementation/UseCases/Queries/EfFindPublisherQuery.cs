using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.DTO.Publisher;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfFindPublisherQuery : EfUseCase, IFindPublisherQuery
    {
        private readonly ReadilyContext _context;

        public EfFindPublisherQuery(ReadilyContext context) : base(context)
        {
            _context = context;
        }

        public int Id => 16;

        public string Name => "Find Publisher";

        public PublisherDto Execute(int search)
        {
            var publisher = Context.Publishers
                .Include(x=>x.Books)
                .FirstOrDefault(x=>x.Id == search && x.IsActive);

            if(publisher == null )
            {
                throw new EntityNotFoundException(search, nameof(Domain.Publisher));
            }

            return new PublisherDto
            {
                Id = publisher.Id,
                Name = publisher.Name,
                BookCount = publisher.Books.Count
            };
        }
    }
}
