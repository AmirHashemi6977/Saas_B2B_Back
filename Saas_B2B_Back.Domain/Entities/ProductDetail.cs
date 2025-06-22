using Saas_B2B_Back.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Domain.Entities
{
    public class ProductDetail:BaseEntity
    {
        

        public string? Dimension { get; set; }

        public string? Weight { get; set; }

        public string? WatteringAmount { get; set; }

        public string? WatteringMethod { get; set; }

        public string? SunAmount { get; set; }

        public string? Material { get; set; }

        public decimal? Price { get; set; }  

        public string? Color { get; set; }

        public string? Description { get; set; } = string.Empty;

        public virtual ICollection<Stock>? Stock { get; set; }

        public required int ProductId { get; set; }  
        public virtual Product? Product { get; set; }  
        



    }
}
