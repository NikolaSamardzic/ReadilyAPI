using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.DTO.Publisher;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfFindPublisherQuery : EfFindUseCase<PublisherDto, Publisher>, IFindPublisherQuery
    {
        public EfFindPublisherQuery(ReadilyContext context, IMapper mapper) : base(context, mapper)
        {
        }

        private EfFindPublisherQuery() { }

        public override int Id => 16;

        public override string Name => "Find Publisher";

        protected override IQueryable<Publisher> IncludeRelatedEntities(IQueryable<Publisher> query)
        {
            return query
                .Include(x => x.Books);
        }
    }
}
