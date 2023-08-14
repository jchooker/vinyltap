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
        Task<List<User>> GetAll(Expression<Func<User, bool>> filter = null);
        Task<User> Get(Expression<Func<User, bool>> filter = null, bool tracked = true);
        Task Create(User entity);
        Task Remove(User entity);

        Task Save();
    }
}