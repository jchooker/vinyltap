using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VinylTap.Models;

namespace VinylTap.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(Expression<Func<User, bool>> filter = null);
        Task<User> GetAsync(Expression<Func<User, bool>> filter = null, bool tracked = true);
        Task CreateAsync(User entity);
        Task RemoveAsync(User entity);
        bool IsUniqueUser(string username);

        Task SaveAsync();
    }
}