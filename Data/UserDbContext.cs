using Microsoft.EntityFrameworkCore;
using VinylTap.Entities;
//using VinylTap.Models;
//^^originally here from Bhrugen's -- modified to accommodate new guy
namespace VinylTap.Data
{
    // public class UserDbContext : IdentityDbContext<ApplicationUser>
    public class UserDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

    //public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {
        public UserDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // public DbSet<ApplicationUser> ApplicationUsers {get; set;} //other dbsets to add?
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User 
                {
                    Id=1,
                    FirstName = "Joseph",
                    LastName = "Hkr",
                    Username = "jchooker",
                    EmailAddress = "jch@yyymail.com"
                }
            );
        }
    }
}