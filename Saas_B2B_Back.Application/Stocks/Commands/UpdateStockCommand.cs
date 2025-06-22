
using MediatR;


namespace Saas_B2B_Back.Application.Stocks.Commands
{

    public class UpdateStockCommand : IRequest<StockResponse>
    {
        public int Id { get; set; }

        public long? ProductDetailId { get; set; }
        public int? WarehouseId { get; set; }

        public int? Quantity { get; set; }

        public int? WastedQuantity { get; set; }


    }

}

