using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Domain.Common
{
    public interface IBaseEntity
    {
        public int Id { get; set; }

        public DateTime InsertDate { get; set; } 

        public DateTime? UpdateDate { get; set; }
    }
}
