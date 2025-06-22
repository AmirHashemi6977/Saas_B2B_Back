using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas_B2B_Back.Domain.Entities;

namespace Saas_B2B_Back.Domain.Interfaces
{
    public interface IGenericRepository<TEntity,TId> where TEntity : class where TId : struct
    {

        Task<TEntity> GetByIdAsync(TId id);

        Task<User> GetUserByPhoneNumberAsync(string phoneNumber);

        Task<User> GetUserByNationalCodeAsync(string nationalCode);

        Task<User> GetUserByEmailAsync(string email);


        Task<IEnumerable<TEntity>> GetAllUserAddressesByUserIdAsync(long userId);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> AddAsync(TEntity entity);

        Task<List<TEntity>> AddListAsync(List<TEntity> entityList);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(TId id);



    }
}

