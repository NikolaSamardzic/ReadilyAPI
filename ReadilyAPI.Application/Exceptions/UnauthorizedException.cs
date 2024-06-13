using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string username, string useCaseName)
            :base($"There was an unauthorized access attempt by {username} for {useCaseName} use case.")
        {
                
        }
    }
}
