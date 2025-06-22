
using MediatR;

namespace Saas_B2B_Back.Application.Products.Queries
{
    public record class GetAllProductQuery:IRequest<List<ProductResponse>>
    {
    }
}
