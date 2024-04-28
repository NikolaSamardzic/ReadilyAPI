using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Tests.Entities
{
    internal class RoleInit
    {
        public static void Execute(ReadilyContext _context)
        {
            var role1 = new Role
            {
                Name = "Admin"
            };

            var role2 = new Role
            {
                Name = "Customer"
            };

            var role3 = new Role
            {
                Name = "Writer"
            };

            _context.Roles.Add(role1);
            _context.Roles.Add(role2);
            _context.Roles.Add(role3);
        }
    }
}
