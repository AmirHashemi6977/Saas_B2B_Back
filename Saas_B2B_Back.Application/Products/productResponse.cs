using Saas_B2B_Back.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas_B2B_Back.Application.Base;

namespace Saas_B2B_Back.Application.Products
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public string? Name {  get; set; }

        public string? Description { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }
        
    }
}
