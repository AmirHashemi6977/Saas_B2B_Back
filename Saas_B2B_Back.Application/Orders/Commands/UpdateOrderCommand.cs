using Saas_B2B_Back.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.Orders.Commands
{

    public class UpdateOrderCommand : IRequest<OrderResponse>
    {
        public long Id { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? OrderStatus { get; set; } // e.g., "Pending", "Processing", "Completed", "Canceled"
        public decimal? TotalPrice { get; set; } // Calculated total price
    }

}

