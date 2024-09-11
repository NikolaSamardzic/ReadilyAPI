using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Domain
{
    public class RoleUseCase
    {
        public int RoleId { get; set; }
        public int UseCaseId { get; set; }

        public virtual Role Role { get; set; }
    }
}
