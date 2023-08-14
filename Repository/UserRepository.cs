using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Linq.Expressions;
using VinylTap.Data;
using VinylTap.Models;
using VinylTap.Repository.IRepository;

namespace VinylTap.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _db;

        public UserRepository(UserDbContext db)
        {
            _db = db;
        }
        public async Task Create(User entity)
        {
            await _db.Users.AddAsync(entity);
            await Save();
        }

        public async Task<User> Get(Expression<Func<User, bool>> filter = null, bool tracked = true)
        {
            IQueryable<User> query = _db.Users;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            IQueryable<User> query = _db.Users;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task Remove(User entity)
        {
            _db.Users.Remove(entity);
            await Save();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
