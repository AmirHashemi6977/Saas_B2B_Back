using Saas_B2B_Back.Application.ProductImage.Queries;
using Saas_B2B_Back.Application.ProductImage;
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
    public class GetAllUserAddressesQueryHandler : IRequestHandler<GetAllUserAddressesQuery, List<UserAddressesResponse>>
    {
        private readonly IGenericRepository<UserAddress, long> _repository;
        public GetAllUserAddressesQueryHandler(IGenericRepository<UserAddress, long> repository)
        {
            _repository = repository;
        }

        public async Task<List<UserAddressesResponse>> Handle(GetAllUserAddressesQuery getAllAddressesUserQuery, CancellationToken cancellationToken)
        {
            var getAllUsersAddresses = await _repository.GetAllAsync();

            if (getAllUsersAddresses is null)
            {
                return null;
            }

            return getAllUsersAddresses
                .Select(user =>
                new UserAddressesResponse
                {
                   
                    UserId= user.UserId,
                    Id = user.Id,
                    Address = user.Address,
                    Area = user.Area,
                    City = user.City,
                    PostalCode = user.PostalCode,
                    InsertDate = user.InsertDate,
                    UpdateDate = user.UpdateDate
                })
                .ToList();
        }

    }
}
