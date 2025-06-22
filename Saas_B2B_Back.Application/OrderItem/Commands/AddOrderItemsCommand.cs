using MediatR;

namespace Saas_B2B_Back.Application.OrderItem.Commands
{
    public record class AddOrderItemsCommand : IRequest<OrderItemsResponse>
    {

        public int Quantity { get; set; }

        public int Unit { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount => Quantity * UnitPrice;

        public decimal DiscountPercent { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal NetAmount { get; set; }

        public decimal ExtraAmount { get; set; }

        public decimal PayableAmount { get; set; }

        public DateTime InsertDate { get; set; } = DateTime.UtcNow;

        public required long OrderId { get; set; }
        public required int ProductId { get; set; }

    }
}
