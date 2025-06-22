using Saas_B2B_Back.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Domain.Entities
{
    public class Permission : BaseEntity
    {
        public required string Name { get; set; } // Read, Write, Delete, Execute, Manage Users, Configure System
        public string? Description { get; set; }
        public virtual ICollection<PermissionRole> PermissionRoles { get; set; } = new List<PermissionRole>();
    }
}
