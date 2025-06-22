using Saas_B2B_Back.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Domain.Entities
{
    public class Stock:BaseEntity
    {
        public int Quantity { get; set; } = 0;

        public int? WastedQuantity {  get; set; }= 0;

        public required long ProductDetailId { get; set; }

        public virtual  ProductDetail ProductDetail { get; set; }

        public int WarehouseId { get; set; }
        public virtual  Warehouse Warehouse { get; set; }

    }
}
