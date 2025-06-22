using Saas_B2B_Back.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Domain.Entities
{
    public class Warehouse:BaseEntity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<Stock>? Stock { get; set; }
    }
}
