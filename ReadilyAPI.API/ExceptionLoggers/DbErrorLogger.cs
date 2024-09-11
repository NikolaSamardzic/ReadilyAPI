using ReadilyAPI.Application.Logging;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;

namespace ReadilyAPI.API.ExceptionLoggers
{
    public class DbErrorLogger : IErrorLogger
    {
        private readonly ReadilyContext _context;

        public DbErrorLogger(ReadilyContext context)
        {
            _context = context;
        }

        public void Log(AppError error)
        {
            ErrorLog log = new ErrorLog
            {
                Id = error.Id,
                Message = error.Exception.Message,
                StackTrace = error.Exception.StackTrace,
                Time = DateTime.UtcNow
            };

            _context.ErrorLogs.Add(log);
            _context.SaveChanges();
        }
    }
}
