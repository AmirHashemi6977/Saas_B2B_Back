using Saas_B2B_Back.Domain.Common;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Domain.Entities
{
    public class Product:BaseEntity
    {

        public required string Name { get; set; }

        public string? Description { get; set; }
  
        public virtual ProductDetail? Detail { get; set; }

        public virtual ICollection<OrderItems>? OrderItems { get; set; }

        public virtual ICollection<ProductImages>? Images { get; set; }

        public virtual ICollection<MetaJunc>? MetaJunc { get; set; }

    }
}
