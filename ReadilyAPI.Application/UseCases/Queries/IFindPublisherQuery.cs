using ReadilyAPI.Application.UseCases.DTO.Publisher;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries
{
    public interface IFindPublisherQuery : IQuery<int, PublisherDto>
    {
    }
}
