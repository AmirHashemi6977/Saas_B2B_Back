using Saas_B2B_Back.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.ProductDetails
{
    public class ProductDetailResponse
    {
        public int ProductId { get; set; }

        public int Id { get; set; }

        public string? Dimension { get; set; }

        public string? Weight { get; set; }

        public string? WatteringAmount { get; set; }

        public string? WatteringMethod { get; set; }

        public string? SunAmount { get; set; }

        public string? Material { get; set; }

        public decimal? Price { get; set; }

        public string? Color { get; set; }

        public string? Description { get; set; }


        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }

    }
}
