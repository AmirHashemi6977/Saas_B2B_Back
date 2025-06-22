using Saas_B2B_Back.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.ProductImage
{
    public class ProductImagesResponse
    {
        public int ProductId { get; set; }
        public int Id { get; set; }

        public string? Url { get; set; }

        public string? Title { get; set; }

        public bool? IsMain { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }

    }
}
