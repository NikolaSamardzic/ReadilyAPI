using Newtonsoft.Json;
using ReadilyAPI.Application.Logging;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Logging
{
    public class EfUseCaseLogger : IUseCaseLogger
    {
        private readonly ReadilyContext _context;

        public EfUseCaseLogger(ReadilyContext context)
        {
            _context = context;
        }

        public void Add(UseCaseLogEntry entry)
        {
            _context.LogEntries.Add(new Domain.LogEntry {
                Actor = entry.Actor,
                ActorId = entry.ActorId,
                UseCaseData = JsonConvert.SerializeObject(entry.Data),
                UseCaseName = entry.UseCaseName,
                CreatedAt = DateTime.UtcNow,
            });

            _context.SaveChanges();
        }
    }
}
