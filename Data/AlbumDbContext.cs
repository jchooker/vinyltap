using Microsoft.EntityFrameworkCore;
using VinylTap.Models;

namespace VinylTap.ClientApp.Data
{
    public class AlbumDbContext : DbContext
    {
        public AlbumDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumOnHand> AlbumsOnHand { get; set; }
        public DbSet<ConfigurationEntity> Configurations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AlbumOnHand>()
                .HasOne(b => b.Album)
                .WithMany(a => a.AlbumsOnHand)
                .HasForeignKey(b => b.AlbumId);
        }
    }
}