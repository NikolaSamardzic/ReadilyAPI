using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Audit
{
    public class LogEntriesDto
    {
        public int Id { get; set; }
        public string Actor {  get; set; }
        public int ActorId { get; set; }
        public string UseCaseData { get; set; }
        public string USeCaseName { get; set; }
        public DateTime Time {  get; set; }
    }
}
