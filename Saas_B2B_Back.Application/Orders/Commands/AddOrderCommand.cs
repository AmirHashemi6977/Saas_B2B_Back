using Saas_B2B_Back.Domain.Entities;
using MediatR;

namespace Saas_B2B_Back.Application.Orders.Commands
{
  public  record class AddOrderCommand : IRequest<OrderResponse>
    {
        public DateTime? DeliveryDate { get; set; }
        public string? OrderStatus { get; set; } = "Pending"; // e.g., "Pending", "Processing", "Completed", "Canceled"
        public decimal TotalPrice { get; set; } // Calculated total price
        public required long UserId { get; set; }



    }
}
