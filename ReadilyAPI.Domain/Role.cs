using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Domain
{
    public class Role : NamedEntity
    {
        public virtual ICollection<RoleUseCase> RoleUseCases { get; set; } = new List<RoleUseCase>();
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
