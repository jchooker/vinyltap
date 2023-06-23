
namespace VinylTap.Models
{
    public class Album
    {
        public int Id { get; set; }
        public int AlbumArtistId { get; set; }
        public string AlbumArtist { get; set; }
        public int AlbumYear { get; set; }
        public string AlbumName { get; set; }
        public string AlbumDescription { get; set; }
        public string AlbumGenre { get; set; }
        public string AlbumLabel { get; set; }
        public string? AlbumCover { get; set; }
        
    }
}