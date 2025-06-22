
using MediatR;

namespace Saas_B2B_Back.Application.Stocks.Commands
{
  public  record class AddStockCommand : IRequest<StockResponse>
    {
        public required long ProductDetailId { get; set; }
        public int? WarehouseId { get; set; }

        public required int Quantity { get; set; }

        public int? WastedQuantity { get; set; }


    }
}
