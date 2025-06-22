using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;
using RandomString4Net;
using BCrypt.Net;

namespace Saas_B2B_Back.Application.Users.Commands.Handler
{
    internal class ForgotPasswordUserCommandHandler : IRequestHandler<ForgotPasswordUserCommand, string>
    {

        private readonly IGenericRepository<User, long> _repository;

        public ForgotPasswordUserCommandHandler(IGenericRepository<User, long> repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(ForgotPasswordUserCommand forgotPasswordUserCommand, CancellationToken cancellationToken)
        {
            User user;

            if (forgotPasswordUserCommand.PhoneNumber is null)
            {
                if (forgotPasswordUserCommand.Email is null)
                {
                    throw new Exception("ورودی غیر معتبر می باشد.");
                }
                else
                    user = await _repository.GetUserByEmailAsync(forgotPasswordUserCommand.Email);

                if (user is null)
                {
                    return null;
                }
            }
            else
                user = await _repository.GetUserByPhoneNumberAsync(forgotPasswordUserCommand.PhoneNumber);
            if (user is null)
            {
                return null;
            }

            string password = RandomString4Net.RandomString.GetString(Types.ALPHANUMERIC_MIXEDCASE_WITH_SYMBOLS, 9);

            string enCodedPass = BCrypt.Net.BCrypt.EnhancedHashPassword(password, HashType.SHA256);

            user.PasswordHash = enCodedPass;

            try
            {
                await _repository.UpdateAsync(user);

                return password;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



    }
}
