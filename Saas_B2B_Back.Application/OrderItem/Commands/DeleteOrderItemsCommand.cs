using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.OrderItem.Commands
{
    public class DeleteOrderItemsCommand:IRequest<bool>
    {
        public long Id { get; set; }
        public DeleteOrderItemsCommand(long id)
        {
            Id = id;
        }
    }
}
