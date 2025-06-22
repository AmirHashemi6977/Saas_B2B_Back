using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Application.Base;
using MediatR;

namespace Saas_B2B_Back.Application.Users.Commands
{
    public partial class ExternalUserAuthCommand : IRequest<UserResponse>
    {

        //public User ProviderId { get; set; } = User.Saas_B2B_Back;
        //public string? Firstname { get; set; }

        //public string? Lastname { get; set; }

        //public bool? SexCode { get; set; }

        //public string? Email { get; set; }

        //public string? PhoneNumber { get; set; }

        //public bool? IsProvider { get; set; }

    }
}
