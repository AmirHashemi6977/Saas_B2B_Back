using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.Users.Commands
{
    public class ChangePasswordUserCommand:IRequest<bool>
    {
        public long Id { get; set; }
        public required string Password { get; set; }
        public required string NewPassword { get; set; }
        public  required string ConfirmPassword { get; set; }

    }
}
