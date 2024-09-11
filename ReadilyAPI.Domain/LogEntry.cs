using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Domain
{
    public class LogEntry : Entity
    {
        public string Actor {  get; set; }
        public int ActorId { get; set; }
        public string UseCaseName { get; set; }
        public string UseCaseData { get; set; }
    }
}
