using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.Logging
{
    public interface IErrorLogger
    {
        void Log(AppError error);
    }

    public class AppError
    {
        public Exception Exception { get; set; }
        public Guid Id { get; set; }
    }
}
