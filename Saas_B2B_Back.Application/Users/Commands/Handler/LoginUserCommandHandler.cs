using BCrypt.Net;
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using Saas_B2B_Back.Application.Common;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using FluentValidation;


namespace Saas_B2B_Back.Application.Users.Commands.Handler
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<string>>
    {
        private IGenericRepository<User, long> _repository;
        private readonly IConfiguration _configuration;
        private readonly IValidator<LoginUserCommand> _userValidator;

        public LoginUserCommandHandler(IGenericRepository<User, long> repository, IConfiguration configuration, IValidator<LoginUserCommand> userValidator = null)
        {
            _repository = repository;
            _configuration = configuration;
            _userValidator = userValidator;
        }

        public async Task<Result<string>> Handle(LoginUserCommand loginUserCommand, CancellationToken cancellationToken)
        {

            var validationResult = await _userValidator.ValidateAsync(loginUserCommand, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Result<string>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

            User UserInDB;
            bool isPassVerified;

            UserInDB = await _repository.GetUserByPhoneNumberAsync(loginUserCommand.PhoneNumber);

            if (UserInDB is null)
            {

                UserInDB = await _repository.GetUserByEmailAsync(loginUserCommand.Email);

                if (UserInDB is null)
                {
                    UserInDB = await _repository.GetUserByNationalCodeAsync(loginUserCommand.NationalCode);

                    if (UserInDB is null)
                    {
                        return null;
                    }

                    else isPassVerified = BCrypt.Net.BCrypt.EnhancedVerify(loginUserCommand.Password, UserInDB.PasswordHash, HashType.SHA256);

                }
                else isPassVerified = BCrypt.Net.BCrypt.EnhancedVerify(loginUserCommand.Password, UserInDB.PasswordHash, HashType.SHA256);

            }

            else isPassVerified = BCrypt.Net.BCrypt.EnhancedVerify(loginUserCommand.Password, UserInDB.PasswordHash, HashType.SHA256);

            if (!isPassVerified)
            {
                return Result<string>.Failure("رمز عبور اشتباه می باشد!");
            }

            var expireDate = DateTime.UtcNow.AddMinutes(30); // Token expiration
            var appSetting = new AppSetting();

            _configuration.Bind(appSetting);

            var createToken = new JwtHandler(appSetting);

            string token;

            if (UserInDB.Email != null)
            {

                token = createToken.Create(new ClaimsIdentity(new[]
                {

                new Claim(ClaimTypes.Email, UserInDB.Email),
                new Claim(ClaimTypes.MobilePhone, UserInDB.PhoneNumber),
                }), expireDate);
            }
            else if (UserInDB.NationalCode != null)
            {

                token = createToken.Create(new ClaimsIdentity(new[]
                    {

                new Claim(ClaimTypes.MobilePhone, UserInDB.PhoneNumber),
                new Claim(ClaimTypes.NameIdentifier, UserInDB.NationalCode)
                }), expireDate);

            }
            else
            {
                token = createToken.Create(new ClaimsIdentity(new[]
                  {
                new Claim(ClaimTypes.MobilePhone, UserInDB.PhoneNumber),
                }), expireDate);

            }

            UserInDB.LastSignedinAt = DateTime.UtcNow;

            try
            {
            await _repository.UpdateAsync(UserInDB);

            }
            catch(Exception ex)
            {
                return Result<string>.Failure($"خطایی در بروزرسانی پایگاه داده به وجود آمده است! {ex.Message}");
            }
            
            return Result<string>.Success(token);

        }
    }
}
