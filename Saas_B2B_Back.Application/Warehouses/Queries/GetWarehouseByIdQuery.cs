
using MediatR;

namespace Saas_B2B_Back.Application.Warehouses.Queries
{
    public record class GetWarehouseByIdQuery : IRequest<WarehouseResponse>
    {
        public int Id { get; set; }
        public GetWarehouseByIdQuery(int id)
        {
            Id = id;
        }
    }
}
