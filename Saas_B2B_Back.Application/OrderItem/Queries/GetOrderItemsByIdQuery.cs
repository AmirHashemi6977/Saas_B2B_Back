
using MediatR;


namespace Saas_B2B_Back.Application.OrderItem.Queries
{
    public record class GetOrderItemsByIdQuery : IRequest<OrderItemsResponse>
    {
        public long Id { get; set; }
        public GetOrderItemsByIdQuery(long id)
        {
            Id = id;
        }
    }
}
