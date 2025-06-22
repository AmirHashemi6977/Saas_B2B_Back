using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;


namespace Saas_B2B_Back.Application.Warehouses.Commands.Handler
{
    public class DeleteWarehouseCommandHandler : IRequestHandler<DeleteWarehouseCommand, bool>
    {
        private readonly IGenericRepository<Warehouse,int> _repository;

        public DeleteWarehouseCommandHandler(IGenericRepository<Warehouse, int> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteWarehouseCommand deleteWarehouseCommand, CancellationToken cancellationToken)
        {
            var getWarehouse = await _repository.GetByIdAsync(deleteWarehouseCommand.Id);

            if (getWarehouse == null)
            {
                return false;
            }
            try
            {
                await _repository.DeleteAsync(getWarehouse.Id);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
