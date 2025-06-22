using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.OrderItem.Commands
{
    public class AddOrderItemsCommandList : IRequest<List<OrderItemsResponse>>
    {
        public List<AddOrderItemsCommand> Item { get; set; } = new List<AddOrderItemsCommand>();
    }
}
