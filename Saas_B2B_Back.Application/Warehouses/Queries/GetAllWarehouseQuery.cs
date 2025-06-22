
using MediatR;

namespace Saas_B2B_Back.Application.Warehouses.Queries
{
    public record class GetAllWarehouseQuery:IRequest<List<WarehouseResponse>>
    {
    }
}
