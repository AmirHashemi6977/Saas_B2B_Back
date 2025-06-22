using Saas_B2B_Back.Application.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.Users.Queries
{
    public record class GetUserAddressesByIdQuery:IRequest<List<UserAddressesResponse>>
    {
        public long Id { get; set; }
        public GetUserAddressesByIdQuery(long id )
        { 
            Id = id;
        }
    }


}
