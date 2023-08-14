using VinylTap.ClientApp.Data;
using VinylTap.Models;

namespace VinylTap.Data
{
    public static class DbInitializer //static so we don't have to create instance to use it
    {
        public static void Initialize(AlbumDbContext context)
        {
            if (context.Albums.Any()) return; //db has been seeded

            // var albums = new List<Album>
            // {
            //     new Album
            //     {
                    
            //     }
            // }

        }
    }
}