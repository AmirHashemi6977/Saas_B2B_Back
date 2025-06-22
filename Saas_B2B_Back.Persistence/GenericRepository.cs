using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saas_B2B_Back.Application.Common.Exceptions;
using Saas_B2B_Back.Domain.Entities;
using Saas_B2B_Back.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Saas_B2B_Back.Persistence
{
    public class GenericRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity : class where TId : struct
    {

        private readonly Saas_B2B_BackDbContext _dbContext;

        public GenericRepository(Saas_B2B_BackDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
           
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
  
        }

        public async Task<List<TEntity>> AddListAsync(List<TEntity> entityList)
        {

            await _dbContext.Set<TEntity>().AddRangeAsync(entityList);
            await _dbContext.SaveChangesAsync();
            return entityList;
        }

        public async Task<bool> DeleteAsync(TId id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }


        public async Task<IEnumerable<TEntity>> GetAllAsync()

        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }


        public async Task<IEnumerable<TEntity>> GetAllUserAddressesByUserIdAsync(long userId)
        {
            return await _dbContext.Set<TEntity>().Where(e=> (e as IUserEntity).UserId == userId).ToListAsync();
        }




        public async Task<TEntity> GetByIdAsync(TId id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);

        }



        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u =>u.Email == email && u.Email!=null);
        }



        public async Task<User> GetUserByNationalCodeAsync(string nationalCode)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.NationalCode == nationalCode && u.NationalCode != null);

        }



        public async Task<User> GetUserByPhoneNumberAsync(string phoneNumber)
        {
           
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber && u.PhoneNumber != null);
           

        }


        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }



    }
}
