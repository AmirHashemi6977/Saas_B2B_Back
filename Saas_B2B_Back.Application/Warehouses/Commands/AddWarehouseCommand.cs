
using MediatR;

namespace Saas_B2B_Back.Application.Warehouses.Commands
{
    public record class AddWarehouseCommand : IRequest<WarehouseResponse>
    {

        public required string Name { get; set; }

        public string? Description { get; set; } = string.Empty;

    }
}
