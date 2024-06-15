using ReadilyAPI.Application.UseCases.DTO.Audit;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries
{
    public interface IFindErrorLogQuery : IQuery<Guid, ErrorLogDto>
    {
    }
}
