using AutoMapper;
using ReadilyAPI.Application.UseCases.DTO.Audit;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Profiles
{
    public class AuditProfile : Profile
    {
        public AuditProfile() 
        {
            CreateMap<LogEntry, LogEntriesDto>()
                .ForMember(d => d.Time, s => s.MapFrom(x => x.CreatedAt));

            CreateMap<ErrorLog, ErrorLogDto>();
        }
    }
}
