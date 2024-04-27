using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Domain
{
    public class Order : Entity
    {
        #region Properties
        public Decimal TotalPrice { get; set; }
        public DateTime? FinishedAt { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public int DeliveryTypeId { get; set; }
        public int? AddressId { get; set; }
        #endregion

        #region Navigation
        public virtual User User { get; set; }
        public virtual OrderStatus Status { get; set; }
        public virtual Address? Address { get; set; }
        public virtual DeliveryType DeliveryType { get; set; }
        public virtual ICollection<BookOrder> BookOrders { get; set; } = new List<BookOrder>();
        #endregion
    }
}
