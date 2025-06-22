
using MediatR;


namespace Saas_B2B_Back.Application.Orders.Queries
{
    public record class GetOrderByIdQuery : IRequest<OrderResponse>
    {
        public long Id { get; set; }
        public GetOrderByIdQuery(long id)
        {
            Id = id;
        }
    }
}
