
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;

namespace Saas_B2B_Back.Application.Orders.Queries.Handler
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, List<OrderResponse>>
    {
        private readonly IGenericRepository<Order, long> _repository;
        public GetAllOrderQueryHandler(IGenericRepository<Order, long> repository)
        {
            _repository = repository;
        }

        public async Task<List<OrderResponse>> Handle(GetAllOrderQuery getAllOrderQuery, CancellationToken cancellationToken)
        {
            var getOrders = await _repository.GetAllAsync();

            if (getOrders is null)
            {
                return null;
            }

            return getOrders
                .Select(order =>
                new OrderResponse
                {
                    Id = order.Id,
                    DeliveryDate = order.DeliveryDate,
                    UserId = order.UserId,
                    InsertDate = order.InsertDate,
                    OrderStatus = order.OrderStatus,
                    TotalPrice = order.TotalPrice,
                    UpdateDate = order.UpdateDate
                })
                .ToList();
        }
    }
}
