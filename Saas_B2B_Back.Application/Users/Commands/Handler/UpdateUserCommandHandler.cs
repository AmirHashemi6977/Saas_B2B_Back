using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.Users.Commands.Handler
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserResponse>
    {
        private readonly IGenericRepository<User, long> _repository;

        public UpdateUserCommandHandler(IGenericRepository<User, long> repository)
        {
            _repository = repository;
        }

        public async Task<UserResponse> Handle(UpdateUserCommand UpdateUserCommand, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(UpdateUserCommand.Id);

            if (user == null)
            {
                return null;
            }

            user.PhoneNumber = UpdateUserCommand.PhoneNumber == null ? user.PhoneNumber : UpdateUserCommand.PhoneNumber;
            user.IsProvider = UpdateUserCommand.IsProvider == null ? user.IsProvider : UpdateUserCommand.IsProvider;
            user.Firstname = UpdateUserCommand.Firstname == null ? user.Firstname : UpdateUserCommand.Firstname;
            user.Lastname = UpdateUserCommand.Lastname == null ? user.Lastname : UpdateUserCommand.Lastname;
            user.Email = UpdateUserCommand.Email == null ? user.Email : UpdateUserCommand.Email;
            user.NationalCode = UpdateUserCommand.NationalCode == null ? user.NationalCode : UpdateUserCommand.NationalCode;
            user.SexCode = UpdateUserCommand.SexCode == null ? user.SexCode : UpdateUserCommand.SexCode;
            user.UpdateDate = DateTime.UtcNow;


            try
            {


                var updatedUser = await _repository.UpdateAsync(user);

                var userRes= new UserResponse
                {

                    Id = updatedUser.Id,
                    NationalCode = updatedUser.NationalCode,
                    SexCode = updatedUser.SexCode,
                    Email = updatedUser.Email,
                    Firstname = updatedUser.Firstname,
                    Lastname = updatedUser.Lastname,
                    PhoneNumber = updatedUser.PhoneNumber,
                    IsProvider = updatedUser.IsProvider,
                    UpdateDate = updatedUser.UpdateDate,

                };

                return userRes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
