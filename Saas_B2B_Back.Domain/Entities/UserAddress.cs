using Saas_B2B_Back.Domain.Common;
using Saas_B2B_Back.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Domain.Entities
{
    public class UserAddress : IUserEntity,IBaseEntity
    {
    
        public required string Address { get; set; }


        public string? City { get; set; }


        public string? Area { get; set; }

        public string? PostalCode { get; set; }
      
       // public long? UserId { get; set; }

        public virtual User?  User{ get; set; }
        public int Id { get; set ; }
        public DateTime InsertDate { get ; set ; }= DateTime.UtcNow;
        public DateTime? UpdateDate { get; set ; }
    }
}
