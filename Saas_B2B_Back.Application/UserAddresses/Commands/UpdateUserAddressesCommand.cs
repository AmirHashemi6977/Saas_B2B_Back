using Saas_B2B_Back.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.Users.Commands
{
    public class UpdateUserAddressesCommand:IRequest<UserAddressesResponse>
    {
        public required int Id { get; set; }

        public string? Address { get; set; }


        public string? City { get; set; }


        public string? Area { get; set; }

        public string? PostalCode { get; set; }


        public UpdateUserAddressesCommand(int id)
        {
            Id = id;
        }
    }
}
