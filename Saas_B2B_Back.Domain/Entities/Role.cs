using Saas_B2B_Back.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Domain.Entities
{
    public class Role : BaseEntity
    {
        public required string Name { get; set; } // Admin, Manager, Customer
        public string? Description { get; set; }

        public int RoleGroupId { get; set; }
        public virtual ICollection<PermissionRole> PermissionRoles { get; set; } = new List<PermissionRole>();
    }
}
