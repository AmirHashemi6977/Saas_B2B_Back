
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;

namespace Saas_B2B_Back.Application.Warehouses.Queries.Handler
{
    public class GetAllWarehouseQueryHandler : IRequestHandler<GetAllWarehouseQuery, List<WarehouseResponse>>
    {
        private readonly IGenericRepository<Warehouse, int> _repository;
        public GetAllWarehouseQueryHandler(IGenericRepository<Warehouse, int> repository)
        {
            _repository = repository;
        }

        public async Task<List<WarehouseResponse>> Handle(GetAllWarehouseQuery getAllWarehouseQuery, CancellationToken cancellationToken)
        {
            var getWarehouses = await _repository.GetAllAsync();

            if (getWarehouses is null)
            {
                return null;
            }

            return getWarehouses
                .Select(Warehouse =>
                new WarehouseResponse
                {
                    Id = Warehouse.Id,
                    Name = Warehouse.Name,
                    Description = Warehouse.Description,
                    InsertDate = Warehouse.InsertDate,
                    UpdateDate = Warehouse.UpdateDate
                }
                )
                .ToList();
        }
    }
}
