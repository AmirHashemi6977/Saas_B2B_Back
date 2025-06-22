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

    public class AddUserAddressesCommandHandler : IRequestHandler<AddUserAddressesCommand, UserAddressesResponse>
    {
        private readonly IGenericRepository<UserAddress, long> _repository;
        public AddUserAddressesCommandHandler(IGenericRepository<UserAddress, long> repository)
        {
            _repository = repository;

        }



        public async Task<UserAddressesResponse> Handle(AddUserAddressesCommand addUserAddressesCommand, CancellationToken cancellationToken)
        {


            var userAddress = new UserAddress
            {
                UserId = addUserAddressesCommand.UserId,
                Address = addUserAddressesCommand.Address,
                Area = addUserAddressesCommand.Area,
                City = addUserAddressesCommand.City,
                PostalCode = addUserAddressesCommand.PostalCode,
            };
            var userAddressInDb = await _repository.AddAsync(userAddress);


            return new UserAddressesResponse
            {
                UserId = userAddressInDb.UserId,
                Address = userAddressInDb.Address,
                Area = userAddressInDb.Area,
                City = userAddressInDb.City,
                PostalCode = userAddressInDb.PostalCode,
                InsertDate = userAddressInDb.InsertDate,
                Id = userAddressInDb.Id
            };
        }



    }

}
