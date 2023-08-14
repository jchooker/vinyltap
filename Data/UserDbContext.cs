using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VinylTap.Models;

namespace VinylTap.Data
{
    public class UserDbContext : IdentityDbContext
    {
        public UserDbContext(DbContextOptions options) : base(options) {
        //public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {

            }

        public DbSet<User> Users { get; set; }
    }
}