

using MediatR;


namespace Saas_B2B_Back.Application.OrderItem.Queries
{
    public record class GetAllOrderItemsQuery:IRequest<List<OrderItemsResponse>>
    {
    }
}
