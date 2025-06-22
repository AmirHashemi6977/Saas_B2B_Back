using MediatR;

namespace Saas_B2B_Back.Application.Users.Commands
{
    public class ForgotPasswordUserCommand : IRequest<string>
    {
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

    }
}
