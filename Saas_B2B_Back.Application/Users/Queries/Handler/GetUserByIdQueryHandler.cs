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
    internal class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly IGenericRepository<User, long> _repository;
        public GetUserByIdQueryHandler(IGenericRepository<User, long> repository)
        {
            _repository = repository;
        }

        public async Task<UserResponse> Handle(GetUserByIdQuery getUserByIdQuery, CancellationToken cancellationToken)
        {

            var getUser = await _repository.GetByIdAsync(getUserByIdQuery.Id);

            if (getUser is null)
            {
                return null;
            }

            return
                new UserResponse
                {
                    Id = getUser.Id,
                    NationalCode = getUser.NationalCode,
                    PhoneNumber = getUser.PhoneNumber,
                    Firstname = getUser.Firstname,
                    Lastname = getUser.Lastname,
                    Email = getUser.Email,
                    IsProvider = getUser.IsProvider,
                    SexCode = getUser.SexCode,
                    UserGroupId = getUser.UserGroupId,
                    LastSigninAt = getUser.LastSignedinAt,
                    InsertDate = getUser.InsertDate,
                    UpdateDate = getUser.UpdateDate
                };
                

        }

      
    }
}
