
namespace Saas_B2B_Back.Application.Orders
{
    public class OrderResponse
    {
        public long Id { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? OrderStatus { get; set; } // e.g., "Pending", "Processing", "Completed", "Canceled"
        public decimal TotalPrice { get; set; } // Calculated total price
        public required long UserId { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateDate { get; set; }

    }
}
