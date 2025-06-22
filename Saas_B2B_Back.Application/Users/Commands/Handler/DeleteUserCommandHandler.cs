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
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IGenericRepository<User, long> _userRepository;

        public DeleteUserCommandHandler(IGenericRepository<User, long> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserCommand deleteUserCommand, CancellationToken cancellationToken)
        {

            var userToDelete = await _userRepository.GetByIdAsync(deleteUserCommand.Id);

            if (userToDelete == null)
            {
                return false;
            }

            userToDelete.IsDeleted = true;

            await _userRepository.UpdateAsync(userToDelete);

            return true;
        }
    }


}
