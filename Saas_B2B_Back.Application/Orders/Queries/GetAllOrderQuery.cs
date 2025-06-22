

using MediatR;


namespace Saas_B2B_Back.Application.Orders.Queries
{
    public record class GetAllOrderQuery:IRequest<List<OrderResponse>>
    {
    }
}
