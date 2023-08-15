using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Linq.Expressions;
using VinylTap.Data;
using VinylTap.Models;
using VinylTap.Models.Dto;
using VinylTap.Repository.IRepository;

namespace VinylTap.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        //private string secretKey;

        public UserRepository(UserDbContext db, IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            //secretKey = configuration.GetValue<string>("ApiSettings:Secret"); //<--need to set this up?
            _userManager = userManager;
        }

        public bool IsUniqueUser(string username)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(x => x.UserName == username);
            if (user == null) return true;
            else return false;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            return await new Task<LoginResponseDTO>();
        }
        public async Task CreateAsync(User entity)
        {
            await _db.Users.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> filter = null, bool tracked = true)
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

        public async Task<List<User>> GetAllAsync(Expression<Func<User, bool>> filter = null)
        {
            IQueryable<User> query = _db.Users;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task RemoveAsync(User entity)
        {
            _db.Users.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
