using MediatR;


namespace Saas_B2B_Back.Application.Stocks.Commands
{
    public class DeleteStockCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteStockCommand(int id)
        {
            Id = id;
        }
    }
}
