
using MediatR;


namespace Saas_B2B_Back.Application.Warehouses.Commands
{

    public class UpdateWarehouseCommand : IRequest<WarehouseResponse>
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }


    }

}

