using Saas_B2B_Back.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Domain.Entities
{
    public class Order : BaseEntity
    {
        public new long Id { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? OrderStatus { get; set; } // e.g., "Pending", "Processing", "Completed", "Canceled"
        public decimal TotalPrice { get; set; } // Calculated total price
        public required long UserId { get; set; }
        public virtual  User User { get; set; }
        public virtual  ICollection<OrderItems> OrderItems { get; set; }
    }
}
