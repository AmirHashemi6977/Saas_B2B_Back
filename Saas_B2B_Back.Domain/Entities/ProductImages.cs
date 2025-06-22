using Saas_B2B_Back.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Domain.Entities
{
    public class ProductImages:BaseEntity
    {

        public string? Url { get; set; }

        public string? Title { get; set; }

        public bool ? IsMain { get; set; }

        public bool ? IsDeleted { get; set; }

        public int ProductId { get; set; }  

        public virtual Product Product { get; set; }



    }
}
