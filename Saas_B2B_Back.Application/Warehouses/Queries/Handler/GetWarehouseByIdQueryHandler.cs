using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;


namespace Saas_B2B_Back.Application.Warehouses.Queries.Handler
{
    public class GetWarehouseByIdQueryHandler : IRequestHandler<GetWarehouseByIdQuery, WarehouseResponse>
    {
        private readonly IGenericRepository<Warehouse, int> _repository;
        public GetWarehouseByIdQueryHandler(IGenericRepository<Warehouse, int> repository)
        {
            _repository = repository;
        }

        public async Task<WarehouseResponse> Handle(GetWarehouseByIdQuery getWarehouseByIdQuery, CancellationToken cancellationToken)
        {
            var Warehouse = await _repository.GetByIdAsync(getWarehouseByIdQuery.Id);

            if (Warehouse is null)
            {
                return null;
            }

            var getWarehouseRes = new WarehouseResponse
            {
                Id = Warehouse.Id,
                Name = Warehouse.Name,
                Description = Warehouse.Description,
                InsertDate = Warehouse.InsertDate,
                UpdateDate = Warehouse.UpdateDate
            };

            return getWarehouseRes;
        }


    }
}
