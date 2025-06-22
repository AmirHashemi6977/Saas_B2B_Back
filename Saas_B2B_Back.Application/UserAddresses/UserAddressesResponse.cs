using Saas_B2B_Back.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.Users
{
    public class UserAddressesResponse
    {
        public long UserId { get; set; }

        public int Id { get; set; }

        public required string Address { get; set; }


        public string? City { get; set; }


        public string? Area { get; set; }

        public string? PostalCode { get; set; }


        public DateTime InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }

    }
}
