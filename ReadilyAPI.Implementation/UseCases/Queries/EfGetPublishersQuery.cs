using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Publisher;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfGetPublishersQuery : EfUseCase, IGetPublishersQuery
    {
        private readonly IMapper _mapper;

        public EfGetPublishersQuery(ReadilyContext context, IMapper mapper) : base(context)
        {
            this._mapper = mapper;
        }

        private EfGetPublishersQuery() { }

        public int Id => 17;

        public string Name => "Get Publishers";

        public PagedResponse<PublisherDto> Execute(PublisherSearch search)
        {
            return Context.Publishers
                .Include(x => x.Books)
                .WhereIf(!string.IsNullOrEmpty(search.Name), x => x.Name.Contains(search.Name))
                .WhereIf(search.MinBookCount.HasValue && search.MinBookCount.Value > 0, x => x.Books.Count >= search.MinBookCount.Value)
                .WhereIf(search.MaxBookCount.HasValue && search.MaxBookCount > 0, x => x.Books.Count <= search.MaxBookCount.Value)
                .Where(x => x.IsActive)
                .AsPagedReponse<Publisher, PublisherDto>(search, _mapper);
        }
    }
}
