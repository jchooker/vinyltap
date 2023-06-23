using Microsoft.EntityFrameworkCore;
using VinylTap.Models;

namespace VinylTap.ClientApp.Data
{
    public class AlbumContext : DbContext
    {
        public AlbumContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumOnHand> AlbumsOnHand { get; set; }
    }
}