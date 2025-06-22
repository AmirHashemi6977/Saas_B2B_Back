using Saas_B2B_Back.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Saas_B2B_Back.Domain.Common.Util;

namespace Saas_B2B_Back.Application.Users.Commands
{
    public class UpdateUserCommand:IRequest<UserResponse>
    {
        public long Id { get; set; }

        public string? NationalCode { get; set; }

        public  string? Firstname { get; set; }

        public  string? Lastname { get; set; }

        public SexType? SexCode { get; set; }

        public string? Email { get; set; }

        public  string? PhoneNumber { get; set; }

        public bool? IsProvider { get; set; }

        public UpdateUserCommand(long id)
        {
            Id = id;
        }
    }
}
