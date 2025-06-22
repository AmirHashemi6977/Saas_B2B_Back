using MediatR;


namespace Saas_B2B_Back.Application.Warehouses.Commands
{
    public class DeleteWarehouseCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteWarehouseCommand(int id)
        {
            Id = id;
        }
    }
}
