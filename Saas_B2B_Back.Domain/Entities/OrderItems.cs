using Saas_B2B_Back.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Domain.Entities
{
    public class OrderItems : BaseEntity
    {
        public new long Id { get; set; }
        public int Quantity { get; set; }

        public int Unit { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount { get; set; }

        public decimal DiscountPercent { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal NetAmount { get; set; }

        public decimal ExtraAmount { get; set; }

        public decimal PayableAmount { get; set; }

        public long OrderId { get; set; }
        public  virtual Order Order { get; set; } // Navigation property to Order
        public int ProductId { get; set; }
        public virtual  Product Product { get; set; } // Navigation property to Product
    }
}

