using BCrypt.Net;
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;


namespace Saas_B2B_Back.Application.Users.Commands.Handler
{

    public class ChangePasswordUserCommandHandler : IRequestHandler<ChangePasswordUserCommand, bool>
    {
        private readonly IGenericRepository<User, long> _userRepository;

        public ChangePasswordUserCommandHandler(IGenericRepository<User, long> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(ChangePasswordUserCommand changePasswordUserCommand, CancellationToken cancellationToken)
        {

            var userToChangePass = await _userRepository.GetByIdAsync(changePasswordUserCommand.Id);

            if (userToChangePass == null)
            {
                return false;
            }


            var isPassVerified = BCrypt.Net.BCrypt.EnhancedVerify(changePasswordUserCommand.Password, userToChangePass.PasswordHash, HashType.SHA256);

            if (!isPassVerified)
            {
                throw new Exception("رمز عبور قبلی اشتباه می باشد!");
            }

            if (changePasswordUserCommand.NewPassword != changePasswordUserCommand.ConfirmPassword)
            {
                throw new Exception("رمز عبور جدید با تایید رمز یکسان نمی باشد!");
            }

            string encodePass = BCrypt.Net.BCrypt.EnhancedHashPassword(changePasswordUserCommand.NewPassword, HashType.SHA256);

            userToChangePass.PasswordHash = encodePass;

            try
            {
                await _userRepository.UpdateAsync(userToChangePass);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }

}

