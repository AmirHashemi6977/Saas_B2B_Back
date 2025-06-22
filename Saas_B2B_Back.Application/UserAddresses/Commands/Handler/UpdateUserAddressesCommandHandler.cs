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

    public class UpdateUserAddressesCommandHandler : IRequestHandler<UpdateUserAddressesCommand, UserAddressesResponse>
    {
        private readonly IGenericRepository<UserAddress, long> _repository;
        public UpdateUserAddressesCommandHandler(IGenericRepository<UserAddress, long> repository)
        {
            _repository = repository;

        }



        public async Task<UserAddressesResponse> Handle(UpdateUserAddressesCommand updateUserAddressesCommand, CancellationToken cancellationToken)
        {


            UserAddress userAddress = await _repository.GetByIdAsync(updateUserAddressesCommand.Id);

            if (userAddress == null)
            {
                return null;
            }


            userAddress.Id = updateUserAddressesCommand.Id;
            userAddress.Address = updateUserAddressesCommand.Address == null ? userAddress.Address : updateUserAddressesCommand.Address;
            userAddress.Area = updateUserAddressesCommand.Area == null ? userAddress.Area : updateUserAddressesCommand.Area;
            userAddress.City = updateUserAddressesCommand.City == null ? userAddress.City : updateUserAddressesCommand.City;
            userAddress.PostalCode = updateUserAddressesCommand.PostalCode == null ? userAddress.PostalCode : updateUserAddressesCommand.PostalCode;
            userAddress.UpdateDate = DateTime.UtcNow;

            try
            {

                var UpdatedInDb = await _repository.UpdateAsync(userAddress);


                var userAddressRes= new UserAddressesResponse
                {
                    UserId = UpdatedInDb.UserId,
                    Id = UpdatedInDb.Id,
                    Address = UpdatedInDb.Address,
                    Area = UpdatedInDb.Area,
                    City = UpdatedInDb.City,
                    PostalCode = UpdatedInDb.PostalCode,
                    UpdateDate = UpdatedInDb.UpdateDate
                };

                return userAddressRes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



    }

}
