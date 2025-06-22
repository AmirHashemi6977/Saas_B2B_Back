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
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery,List<UserResponse>>
    {
        private readonly IGenericRepository<User, long> _repository;
        public GetAllUserQueryHandler(IGenericRepository<User, long> repository)
        {
            _repository = repository;
        }

        public async Task<List<UserResponse>> Handle(GetAllUserQuery getAllUserQuery, CancellationToken cancellationToken)
        {
            var getAllUsers = await _repository.GetAllAsync();

            if (getAllUsers is null)
            {
                return null;
            }

            return getAllUsers
                .Select(user =>
                new UserResponse
                {
                    Id = user.Id,
                    NationalCode=user.NationalCode,
                    PhoneNumber=user.PhoneNumber,
                    Firstname=user.Firstname,
                    Lastname=user.Lastname,
                    Email=user.Email,
                    IsProvider=user.IsProvider,
                    SexCode=user.SexCode,
                    UserGroupId=user.UserGroupId,
                    LastSigninAt=user.LastSignedinAt,
                    InsertDate = user.InsertDate,
                    UpdateDate = user.UpdateDate
                })
                .ToList();
        }

    }
}
