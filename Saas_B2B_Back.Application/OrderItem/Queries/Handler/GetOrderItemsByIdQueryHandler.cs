
using Saas_B2B_Back.Application.OrderItem;
using Saas_B2B_Back.Application.OrderItem.Queries;
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;


namespace Saas_B2B_Back.Application.OrderItem.Queries.Handler
{
    public class GetOrderItemsByIdQueryHandler : IRequestHandler<GetOrderItemsByIdQuery, OrderItemsResponse>
    {
        private readonly IGenericRepository<OrderItems, long> _repository;
        public GetOrderItemsByIdQueryHandler(IGenericRepository<OrderItems, long> repository)
        {
            _repository = repository;
        }

        public async Task<OrderItemsResponse> Handle(GetOrderItemsByIdQuery getOrderItemsByIdQuery, CancellationToken cancellationToken)
        {
            var OrderItems = await _repository.GetByIdAsync(getOrderItemsByIdQuery.Id);

            if (OrderItems is null)
            {
                return null;
            }

            var getOrderItemsRes = new OrderItemsResponse
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
                Unit = OrderItems.Unit,
                InsertDate = OrderItems.InsertDate,
                UpdateDate = OrderItems.UpdateDate,
            };

            return getOrderItemsRes;
        }


    }
}
