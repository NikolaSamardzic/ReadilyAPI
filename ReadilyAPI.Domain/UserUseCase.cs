using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Domain
{
    public class UserUseCase
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }
        public bool Status { get; set; }

        public virtual User User { get; set; }
    }
}
