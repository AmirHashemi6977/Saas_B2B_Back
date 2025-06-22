
using MediatR;

namespace Saas_B2B_Back.Application.Products.Commands
{
  public  record class AddProductCommand : IRequest<ProductResponse>
    {
        public required string Name { get; set; }

        public string? Description { get; set; }

    }
}
