using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;

namespace Saas_B2B_Back.Application.Orders.Commands
{

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderResponse>
    {
        private readonly IGenericRepository<Order, long> _repository;

        public UpdateOrderCommandHandler(IGenericRepository<Order, long> repository)
        {
            _repository = repository;
        }

        public async Task<OrderResponse> Handle(UpdateOrderCommand updateOrderCommand, CancellationToken cancellationToken)
        {

            var OrderToUpdate = await _repository.GetByIdAsync(updateOrderCommand.Id);

            if (OrderToUpdate == null)
            {
                return null;
            }

            OrderToUpdate.DeliveryDate = updateOrderCommand.DeliveryDate;
            OrderToUpdate.TotalPrice = updateOrderCommand.TotalPrice is null ? OrderToUpdate.TotalPrice : (decimal)updateOrderCommand.TotalPrice;
            OrderToUpdate.OrderStatus = updateOrderCommand.OrderStatus is null ? OrderToUpdate.OrderStatus : updateOrderCommand.OrderStatus;
            OrderToUpdate.UpdateDate = DateTime.UtcNow;

            try
            {

                var updatedOrder = await _repository.UpdateAsync(OrderToUpdate);

                var OrderRes = new OrderResponse
                {
                    Id = updatedOrder.Id,
                    DeliveryDate = updatedOrder.DeliveryDate,
                    TotalPrice = updatedOrder.TotalPrice,
                    UpdateDate = updatedOrder.UpdateDate,
                    OrderStatus = updatedOrder.OrderStatus,
                    UserId = updatedOrder.UserId,
                };


                return OrderRes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }
    }

}
