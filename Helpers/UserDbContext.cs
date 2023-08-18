using Microsoft.EntityFrameworkCore;
using System.Configuration;
using VinylTap.Entities;
//using VinylTap.Models;
//^^originally here from Bhrugen's -- modified to accommodate new guy
namespace VinylTap.Helpers
{
    // public class UserDbContext : IdentityDbContext<ApplicationUser>
    public class UserDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        //public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {
        public UserDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // public DbSet<ApplicationUser> ApplicationUsers {get; set;} //other dbsets to add?

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Joseph",
                    LastName = "Hkr",
                    Username = "jchooker",
                    EmailAddress = "jch@yyymail.com"
                }
            );
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
            // connect to sql server database
            //options.UseSqlServer(Configuration.GetConnectionString("UserConnection"));
            //base.OnConfiguring(options);
        //} ^^^ when it is pushed into prod??
        public DbSet<User> Users { get; set; }
    }
}