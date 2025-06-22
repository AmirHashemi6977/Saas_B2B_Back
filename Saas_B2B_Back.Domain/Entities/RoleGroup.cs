using Saas_B2B_Back.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Domain.Entities
{
    public class RoleGroup : BaseEntity
    {
        public required int Code { get; set; }
        public required string Name { get; set; } // Admin Group, Management Group
        public string? Description { get; set; }
        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
