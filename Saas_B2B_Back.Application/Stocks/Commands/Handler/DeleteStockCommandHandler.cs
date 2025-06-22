using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;


namespace Saas_B2B_Back.Application.Stocks.Commands.Handler
{
    public class DeleteStockCommandHandler : IRequestHandler<DeleteStockCommand, bool>
    {
        private readonly IGenericRepository<Stock,int> _repository;

        public DeleteStockCommandHandler(IGenericRepository<Stock, int> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteStockCommand deleteStockCommand, CancellationToken cancellationToken)
        {
            var getStock = await _repository.GetByIdAsync(deleteStockCommand.Id);

            if (getStock == null)
            {
                return false;
            }
            try
            {
                await _repository.DeleteAsync(getStock.Id);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
