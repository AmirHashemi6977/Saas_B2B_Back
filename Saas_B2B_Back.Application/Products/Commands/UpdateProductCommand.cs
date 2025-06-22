
using MediatR;


namespace Saas_B2B_Back.Application.Products.Commands
{

    public class UpdateProductCommand : IRequest<ProductResponse>
    {
        public long Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
    }

}

