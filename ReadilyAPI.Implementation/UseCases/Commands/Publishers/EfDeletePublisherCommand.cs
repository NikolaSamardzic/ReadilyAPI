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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReadilyAPI.Implementation.UseCases.Commands.Publishers
{
    public class EfDeletePublisherCommand : EfDeleteUseCase<Publisher>, IDeletePublisherCommand
    {
        public EfDeletePublisherCommand(ReadilyContext context) : base(context)
        {
        }

        private EfDeletePublisherCommand() { }

        public override int Id => 15;

        public override string Name => "Delete Publisher";

        protected override IQueryable<Publisher> IncludeRelatedEntities(IQueryable<Publisher> query)
        {
            return query
                    .Include(x => x.Books);
        }

        protected override void BeforeDelete(Publisher entity)
        {
            if (entity.Books.Any())
            {
                throw new EntityReferencedException(entity.Id, nameof(Domain.Publisher));
            }
        }
    }
}
