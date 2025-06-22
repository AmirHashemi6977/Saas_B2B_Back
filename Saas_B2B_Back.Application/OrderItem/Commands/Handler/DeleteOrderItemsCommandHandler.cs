using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;


namespace Saas_B2B_Back.Application.OrderItem.Commands.Handler
{
    public class DeleteOrderItemsCommandHandler : IRequestHandler<DeleteOrderItemsCommand, bool>
    {
        private readonly IGenericRepository<OrderItems,long> _repository;

        public DeleteOrderItemsCommandHandler(IGenericRepository<OrderItems, long> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteOrderItemsCommand deleteOrderItemsCommand, CancellationToken cancellationToken)
        {
            var getOrderItems = await _repository.GetByIdAsync(deleteOrderItemsCommand.Id);

            if (getOrderItems == null)
            {
                return false;
            }
            try
            {
                await _repository.DeleteAsync(getOrderItems.Id);
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
