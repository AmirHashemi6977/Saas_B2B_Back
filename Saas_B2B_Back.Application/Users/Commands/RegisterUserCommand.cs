using Saas_B2B_Back.Application.Common;

using MediatR;

using static Saas_B2B_Back.Domain.Common.Util;

namespace Saas_B2B_Back.Application.Users.Commands
{
    public class RegisterUserCommand : IRequest<Result<UserResponse>>
    {

        public string? NationalCode { get; set; }

        public required string Firstname { get; set; }

        public required string Lastname { get; set; }

        public SexType? SexCode { get; set; }

        public string? Email { get; set; }

        public required string Password { get; set; }

        public required string ConfirmPassword { get; set; }

        public required string PhoneNumber { get; set; }

        public required int UserGroupId { get; set; }

        public bool? IsProvider { get; set; }


    }

}
