using Saas_B2B_Back.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.Users.Commands
{
    public class LoginUserCommand:IRequest<Result<string>>
    {
        public string? PhoneNumber { get; set; }

        public string? NationalCode { get; set; }

        public string? Email { get; set; }

        public required string Password { get; set; }

    }
}
