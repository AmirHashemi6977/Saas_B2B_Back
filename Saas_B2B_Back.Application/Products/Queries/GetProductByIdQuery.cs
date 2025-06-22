
using MediatR;

namespace Saas_B2B_Back.Application.Products.Queries
{
    public record class GetProductByIdQuery : IRequest<ProductResponse>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
