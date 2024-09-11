using ReadilyAPI.Application.Logging;
using System.Text;

namespace ReadilyAPI.API.ExceptionLoggers
{
    public class ConsoleErrorLogger : IErrorLogger
    {
        public void Log(AppError error)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Error id: " + error.Id);
            builder.AppendLine("Error time: " + DateTime.UtcNow);
            builder.AppendLine("Error message: " + error.Exception.Message);
            builder.AppendLine("Error stack trace: " + error.Exception.StackTrace);

            Console.WriteLine(builder.ToString());
        }
    }
}
