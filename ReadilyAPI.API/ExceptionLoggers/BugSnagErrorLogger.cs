using Bugsnag;
using ReadilyAPI.Application.Logging;
using ReadilyAPI.Domain;

namespace ReadilyAPI.API.ExceptionLoggers
{
    public class BugSnagErrorLogger : IErrorLogger
    {
        private readonly Bugsnag.IClient _bugsnag;

        public BugSnagErrorLogger(IClient bugsnag)
        {
            _bugsnag = bugsnag;
        }

        public void Log(AppError error)
        {
            _bugsnag.Notify(error.Exception, (report) =>
            {
                report.Event.Metadata.Add("Error", new Dictionary<string, string>
                {
                    {"Error id", Guid.NewGuid().ToString() },
                    {"Error time", DateTime.UtcNow.ToLongDateString() },
                    {"Error message", error.Exception.Message.ToString() },
                    {"Error stack trace", error.Exception.StackTrace }
                });
            });
        }
    }
}
