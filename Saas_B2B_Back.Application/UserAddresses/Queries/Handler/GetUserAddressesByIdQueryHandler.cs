using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.Users.Queries.Handler
{
    internal class GetUserAddressesByIdQueryHandler : IRequestHandler<GetUserAddressesByIdQuery, List<UserAddressesResponse>>
    {
        private readonly IGenericRepository<UserAddress, long> _repository;
        public GetUserAddressesByIdQueryHandler(IGenericRepository<UserAddress, long> repository)
        {
            _repository = repository;
        }

        public async Task<List<UserAddressesResponse>> Handle(GetUserAddressesByIdQuery getUserAddressesByIdQuery, CancellationToken cancellationToken)
        {

            var getUserAddresses = await _repository.GetAllUserAddressesByUserIdAsync(getUserAddressesByIdQuery.Id);

            if (getUserAddresses.Count() == 0)
            {
                return null;
            }

            return getUserAddresses
                .Select(userAddresses => new UserAddressesResponse
                {
                    UserId = userAddresses.UserId,
                    Id = userAddresses.Id,
                    Area = userAddresses.Area,
                    City = userAddresses.City,
                    PostalCode = userAddresses.PostalCode,
                    Address = userAddresses.Address,
                    InsertDate = userAddresses.InsertDate,
                    UpdateDate = userAddresses.UpdateDate

                }).ToList();



        }


    }
}
