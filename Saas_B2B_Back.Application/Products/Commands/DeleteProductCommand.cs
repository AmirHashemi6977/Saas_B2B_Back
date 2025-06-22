using MediatR;


namespace Saas_B2B_Back.Application.Products.Commands
{
    public class DeleteProductCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
