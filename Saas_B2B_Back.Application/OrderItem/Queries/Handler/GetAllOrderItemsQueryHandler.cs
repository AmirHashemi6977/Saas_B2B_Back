
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;

namespace Saas_B2B_Back.Application.OrderItem.Queries.Handler
{
    public class GetAllOrderItemsQueryHandler : IRequestHandler<GetAllOrderItemsQuery, List<OrderItemsResponse>>
    {
        private readonly IGenericRepository<OrderItems, long> _repository;
        public GetAllOrderItemsQueryHandler(IGenericRepository<OrderItems, long> repository)
        {
            _repository = repository;
        }

        public async Task<List<OrderItemsResponse>> Handle(GetAllOrderItemsQuery getAllOrderItemsQuery, CancellationToken cancellationToken)
        {
            var getOrderItemss = await _repository.GetAllAsync();

            if (getOrderItemss is null)
            {
                return null;
            }

            return getOrderItemss
                .Select(OrderItems =>
                new OrderItemsResponse
                {
                    Id = OrderItems.Id,
                    OrderId = OrderItems.OrderId,
                    ProductId = OrderItems.ProductId,
                    Amount = OrderItems.Amount,
                    DiscountAmount = OrderItems.DiscountAmount,
                    DiscountPercent = OrderItems.DiscountPercent,
                    ExtraAmount = OrderItems.ExtraAmount,
                    NetAmount = OrderItems.NetAmount,
                    PayableAmount = OrderItems.PayableAmount,
                    Quantity = OrderItems.Quantity,
                    TaxAmount = OrderItems.TaxAmount,
                    UnitPrice = OrderItems.UnitPrice,
                    Unit= OrderItems.Unit,
                    InsertDate = OrderItems.InsertDate,
                    UpdateDate= OrderItems.UpdateDate,
                })
                .ToList();
        }
    }
}
