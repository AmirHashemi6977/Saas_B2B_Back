using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Saas_B2B_Back.Application.OrderItem.Commands
{

    public class UpdateOrderItemsCommandHandler : IRequestHandler<UpdateOrderItemsCommand, OrderItemsResponse>
    {
        private readonly IGenericRepository<OrderItems, long> _repository;

        public UpdateOrderItemsCommandHandler(IGenericRepository<OrderItems, long> repository)
        {
            _repository = repository;
        }

        public async Task<OrderItemsResponse> Handle(UpdateOrderItemsCommand updateOrderItemsCommand, CancellationToken cancellationToken)
        {

            var OrderItemsToUpdate = await _repository.GetByIdAsync(updateOrderItemsCommand.Id);

            if (OrderItemsToUpdate == null)
            {
                return null;
            }

            OrderItemsToUpdate.ProductId = updateOrderItemsCommand.ProductId is null ? OrderItemsToUpdate.ProductId : (int)updateOrderItemsCommand.ProductId;
            OrderItemsToUpdate.Quantity = updateOrderItemsCommand.Quantity is null ? OrderItemsToUpdate.Quantity : (int)updateOrderItemsCommand.Quantity;
            OrderItemsToUpdate.Unit = updateOrderItemsCommand.Unit is null ? OrderItemsToUpdate.Unit : (int)updateOrderItemsCommand.Unit;
            OrderItemsToUpdate.UnitPrice = updateOrderItemsCommand.UnitPrice is null ? OrderItemsToUpdate.UnitPrice : (decimal)updateOrderItemsCommand.UnitPrice;
            OrderItemsToUpdate.Amount = updateOrderItemsCommand.Amount is null ? OrderItemsToUpdate.Amount : (decimal)updateOrderItemsCommand.Amount;
            OrderItemsToUpdate.DiscountAmount = updateOrderItemsCommand.DiscountAmount is null ? OrderItemsToUpdate.DiscountAmount : (decimal)updateOrderItemsCommand.DiscountAmount;
            OrderItemsToUpdate.DiscountPercent = updateOrderItemsCommand.DiscountPercent is null ? OrderItemsToUpdate.DiscountPercent : (decimal)updateOrderItemsCommand.DiscountPercent;
            OrderItemsToUpdate.NetAmount = updateOrderItemsCommand.NetAmount is null ? OrderItemsToUpdate.NetAmount : (decimal)updateOrderItemsCommand.NetAmount;
            OrderItemsToUpdate.TaxAmount = updateOrderItemsCommand.TaxAmount is null ? OrderItemsToUpdate.TaxAmount : (decimal)updateOrderItemsCommand.TaxAmount;
            OrderItemsToUpdate.ExtraAmount = updateOrderItemsCommand.ExtraAmount is null ? OrderItemsToUpdate.ExtraAmount : (decimal)updateOrderItemsCommand.ExtraAmount;
            OrderItemsToUpdate.PayableAmount = updateOrderItemsCommand.PayableAmount is null ? OrderItemsToUpdate.PayableAmount : (decimal)updateOrderItemsCommand.PayableAmount;
            OrderItemsToUpdate.UpdateDate = DateTime.UtcNow;

            try
            {
                var updatedOrderItems = await _repository.UpdateAsync(OrderItemsToUpdate);

                var OrderItemsRes = new OrderItemsResponse
                {
                    Id = updatedOrderItems.Id,
                    OrderId = updatedOrderItems.Id,
                    ProductId = updatedOrderItems.ProductId,
                    Quantity = updatedOrderItems.Quantity,
                    Unit = updatedOrderItems.Unit,
                    UnitPrice = updatedOrderItems.UnitPrice,
                    Amount = updatedOrderItems.Amount,
                    DiscountAmount = updatedOrderItems.DiscountAmount,
                    DiscountPercent = updatedOrderItems.DiscountPercent,
                    NetAmount = updatedOrderItems.NetAmount,
                    TaxAmount = updatedOrderItems.TaxAmount,
                    ExtraAmount = updatedOrderItems.ExtraAmount,
                    PayableAmount = updatedOrderItems.PayableAmount,
                    UpdateDate = updatedOrderItems.UpdateDate,
                };


                return OrderItemsRes;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }



        }
    }

}
