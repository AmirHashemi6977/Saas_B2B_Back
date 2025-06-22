using Saas_B2B_Back.Application.Common.Utilities;
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Saas_B2B_Back.Application.Users.Commands.Handler
{

    public class DeleteUserAddressesCommandHandler : IRequestHandler<DeleteUserAddressesCommand, bool>
    {
        private readonly IGenericRepository<UserAddress, long> _repository;
        public DeleteUserAddressesCommandHandler(IGenericRepository<UserAddress, long> repository)
        {
            _repository = repository;

        }



        public async Task<bool> Handle(DeleteUserAddressesCommand deleteUserAddressesCommand, CancellationToken cancellationToken)
        {


            var getUserAddressById = await _repository.GetByIdAsync(deleteUserAddressesCommand.Id);
            if (getUserAddressById == null)
            {
                return false;
            }

            
            var isDeletedAddress = await _repository.DeleteAsync(getUserAddressById.Id);


            return isDeletedAddress;
        }



    }

}
