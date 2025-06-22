using Saas_B2B_Back.Application.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.Users.Queries
{
    public record class GetUserByIdQuery:IRequest<UserResponse>
    {
        public long Id { get; set; }
        public GetUserByIdQuery(long id )
        { 
            Id = id;
        }
    }


}
