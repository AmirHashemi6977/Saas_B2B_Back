using Saas_B2B_Back.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Domain.Entities
{
    public class MetaJunc:BaseEntity
    {
        
        public int ProductId { get; set; }

        public int MetaId   { get; set; }

        public virtual Product? Product { get; set; }

        public virtual Meta? Meta { get; set; }

    }
}
