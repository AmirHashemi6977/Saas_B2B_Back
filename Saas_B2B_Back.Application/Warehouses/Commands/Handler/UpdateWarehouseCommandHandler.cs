using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;

namespace Saas_B2B_Back.Application.Warehouses.Commands
{

    public class UpdateWarehouseCommandHandler : IRequestHandler<UpdateWarehouseCommand, WarehouseResponse>
    {
        private readonly IGenericRepository<Warehouse, int> _repository;

        public UpdateWarehouseCommandHandler(IGenericRepository<Warehouse, int> repository)
        {
            _repository = repository;
        }

        public async Task<WarehouseResponse> Handle(UpdateWarehouseCommand updateWarehouseCommand, CancellationToken cancellationToken)
        {

            var WarehouseToUpdate = await _repository.GetByIdAsync(updateWarehouseCommand.Id);

            if (WarehouseToUpdate == null)
            {
                return null;
            }


            WarehouseToUpdate.Name = updateWarehouseCommand.Name is null ? WarehouseToUpdate.Name : updateWarehouseCommand.Name;
            WarehouseToUpdate.Description = updateWarehouseCommand.Description is null ? WarehouseToUpdate.Description : updateWarehouseCommand.Description;
            WarehouseToUpdate.UpdateDate = DateTime.UtcNow;


            try
            {
                var updatedWarehouse = await _repository.UpdateAsync(WarehouseToUpdate);

                var WarehouseRes = new WarehouseResponse
                {
                    Id = updatedWarehouse.Id,
                    Name = updatedWarehouse.Name,
                    Description = updatedWarehouse.Description,
                    UpdateDate = updatedWarehouse.UpdateDate,
                    InsertDate = updatedWarehouse.InsertDate
                };


                return WarehouseRes;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }

}
