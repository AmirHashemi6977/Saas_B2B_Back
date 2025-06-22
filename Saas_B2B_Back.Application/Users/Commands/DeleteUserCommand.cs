using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.Users.Commands
{
    public class DeleteUserCommand:IRequest<bool>
    {
        public long Id { set; get; }

        public DeleteUserCommand(long id)
        {
            Id = id;
        }
    }
}
