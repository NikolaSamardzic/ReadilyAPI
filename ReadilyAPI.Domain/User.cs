using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Domain
{
    public class User : Entity
    {
        #region Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public DateTime? EmailVerifiedAt { get; set; }
        public string Phone { get; set; }
        public string Token { get; set; }
        public bool IsBanned { get; set; }
        public int? AddressId { get; set; }
        public int RoleId { get; set; }
        public int AvatarId { get; set; } 
        #endregion

        #region Navigation
        public virtual Address? Address { get; set; }
        public virtual Role Role { get; set; }
        public virtual Image Avatar { get; set; }
        public virtual Biography? Biography { get; set; }
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<Order> Orders { get; set; }
        #endregion
    }
}
