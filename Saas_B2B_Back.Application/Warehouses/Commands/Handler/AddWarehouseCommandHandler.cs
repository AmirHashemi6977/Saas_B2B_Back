
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;


namespace Saas_B2B_Back.Application.Warehouses.Commands
{
    public class AddWarehouseCommandHandler : IRequestHandler<AddWarehouseCommand, WarehouseResponse>
    {
        private readonly IGenericRepository<Warehouse, int> _repository;
        public AddWarehouseCommandHandler(IGenericRepository<Warehouse, int> repository)
        {
            _repository = repository;
        }

        public async Task<WarehouseResponse> Handle(AddWarehouseCommand addWarehouseCommand, CancellationToken cancellationToken)
        {
            var Warehouse = new Warehouse
            {
                Name = addWarehouseCommand.Name,
                Description = addWarehouseCommand.Description,
                InsertDate = DateTime.UtcNow,
            };

            try
            {
                var WarehouseCreatedInDb = await _repository.AddAsync(Warehouse);

                var WarehouseRes = new WarehouseResponse
                {
                    Id = WarehouseCreatedInDb.Id,
                    Name = WarehouseCreatedInDb.Name,
                    Description = WarehouseCreatedInDb.Description,
                    InsertDate = WarehouseCreatedInDb.InsertDate
                };

                return WarehouseRes;
            }
            catch (Exception ex)
            {
                return null;
            }



        }


    }


}

