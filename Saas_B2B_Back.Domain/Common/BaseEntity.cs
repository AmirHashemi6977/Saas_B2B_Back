using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Domain.Common
{
    public class BaseEntity:IBaseEntity
    {
        public int Id { get; set; }

        public DateTime InsertDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdateDate { get; set; } 

    }

}
