
using Saas_B2B_Back.Domain.Entities;

namespace Saas_B2B_Back.Application.OrderItem
{
    public class OrderItemsResponse
    {
        public long Id { get; set; }
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

        public DateTime InsertDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdateDate { get; set; }

        public long OrderId { get; set; }
        public int ProductId { get; set; }

    }
}
