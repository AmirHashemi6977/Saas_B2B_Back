using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.ProductDetails.Commands
{
    public class DeleteProductDetailCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteProductDetailCommand(int id)
        {
            Id = id;
        }
    }
}
