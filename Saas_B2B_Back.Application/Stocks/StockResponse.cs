using Saas_B2B_Back.Domain.Entities;

namespace Saas_B2B_Back.Application.Stocks
{
    public class StockResponse
    {
        public int Id { get; set; }
        public long? ProductDetailId { get; set; }
        public int? WarehouseId { get; set; }

        public int? Quantity { get; set; } 

        public int? WastedQuantity { get; set; } 


        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }
        
    }
}
