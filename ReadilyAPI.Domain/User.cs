using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public DateTime? EmailVerifiedAt { get; set; }
        public string Phone {  get; set; }
        public string Token { get; set; }
        public bool IsBanned { get; set; }
        public int? AddressId { get; set; }  
        public int RoleId { get; set; }
        public int AvatarId {  get; set; }

        public Address? Address { get; set; }
        public Role Role { get; set; }
        public Image Avatar { get; set; }
    }
}
