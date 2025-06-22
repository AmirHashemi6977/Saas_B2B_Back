
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;


namespace Saas_B2B_Back.Application.Orders.Queries.Handler
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderResponse>
    {
        private readonly IGenericRepository<Order, long> _repository;
        public GetOrderByIdQueryHandler(IGenericRepository<Order, long> repository)
        {
            _repository = repository;
        }

        public async Task<OrderResponse> Handle(GetOrderByIdQuery getOrderByIdQuery, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(getOrderByIdQuery.Id);

            if (order is null)
            {
                return null;
            }

            var getOrderRes = new OrderResponse
            {
                Id = order.Id,
                DeliveryDate = order.DeliveryDate,
                UserId = order.UserId,
                InsertDate = order.InsertDate,
                OrderStatus = order.OrderStatus,
                TotalPrice = order.TotalPrice,
                UpdateDate = order.UpdateDate
            };

            return getOrderRes;
        }


    }
}
