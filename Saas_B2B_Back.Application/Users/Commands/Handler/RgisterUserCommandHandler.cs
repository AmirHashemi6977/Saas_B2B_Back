using BCrypt.Net;
using Saas_B2B_Back.Application.Common;
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using FluentValidation;
using MediatR;

namespace Saas_B2B_Back.Application.Users.Commands.Handler
{

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Result<UserResponse>>
    {
        private readonly IGenericRepository<User, long> _userRepository;
        private readonly IValidator<RegisterUserCommand> _userValidator;

        public RegisterUserCommandHandler(IGenericRepository<User, long> userRepository, IValidator<RegisterUserCommand> userValidator)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
        }



        public async Task<Result<UserResponse>> Handle(RegisterUserCommand registerUserCommand, CancellationToken cancellationToken)
        {

            var validationResult = await _userValidator.ValidateAsync(registerUserCommand, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Result<UserResponse>.Failure(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

            string encodePass = BCrypt.Net.BCrypt.EnhancedHashPassword(registerUserCommand.Password, HashType.SHA256);

            var user = new User
            {
                Firstname = registerUserCommand.Firstname,
                Lastname = registerUserCommand.Lastname,
                PhoneNumber = registerUserCommand.PhoneNumber,
                Email = registerUserCommand.Email,
                PasswordHash = encodePass,
                SexCode = registerUserCommand.SexCode,
                NationalCode = registerUserCommand.NationalCode,
                IsProvider = registerUserCommand.IsProvider,
                UserGroupId = registerUserCommand.UserGroupId
            };

         

            try
            {

                var createdUser = await _userRepository.AddAsync(user);


                var userRegisterRes= new UserResponse
                {
                    Id = createdUser.Id,
                    Firstname = createdUser.Firstname,
                    Lastname = createdUser.Lastname,
                    PhoneNumber = createdUser.PhoneNumber,
                    Email = createdUser.Email,
                    SexCode = createdUser.SexCode,
                    NationalCode = createdUser.NationalCode,
                    UserGroupId= createdUser.UserGroupId,
                    IsProvider = createdUser.IsProvider,
                    InsertDate = createdUser.InsertDate
                };

                return Result<UserResponse>.Success(userRegisterRes);
            }
            catch (Exception ex)
            {
                return Result<UserResponse>.Failure(new List<string> { ex.Message });

            }

        }



    }

}
