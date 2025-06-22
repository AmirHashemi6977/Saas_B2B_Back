using Saas_B2B_Back.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Domain.Entities
{
    public class UserRole:BaseEntity
    {

        public required long UserId { get; set; }
       // public required long RoleId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;

        ////Admin 
        ////Manager
        ////Customer
        //public required string Name { get; set; }



        ////Admin=> Full access to system administration, including user management, data access, and configuration changes.
        ////Manager=> Access to reports, user management, and limited data access.
        ////Customer=> Access to basic application functionalities and personal data.
        //public string? Description { get; set; }


        ////Admin=> Read, Write, Delete, Execute, Manage Users, Configure System
        ////Manager=> Read, Write, Manage Users
        ////Customer=> Read
        //public required string Permissions { get; set; }


        ////Admin=> All databases, system files, configuration settings
        ////Manager=> Customer data, employee information, reports
        ////Customer=> Publicly available content, user profile
        //public  required string ResourceAccess { get; set; }

        //public bool ActiveStatus { get; set; }


        //public long? UserId { get; set; }

        //public virtual User? User { get; set; }



    }
}
