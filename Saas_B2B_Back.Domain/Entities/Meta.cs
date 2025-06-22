using Saas_B2B_Back.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Domain.Entities
{
    public class Meta : BaseEntity
    {

        public required string Title { get; set; }

        public string? Description { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<MetaJunc>? MetaJunc { get; set; }
    }
}
