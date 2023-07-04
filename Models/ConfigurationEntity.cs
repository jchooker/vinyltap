using System.ComponentModel.DataAnnotations;

namespace VinylTap.Models
{
    public class ConfigurationEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ConsumerKey { get; set; }
        [Required]
        public string ConsumerSecret { get; set; }
        [Required]
        public string OAuthToken { get; set; }
        [Required]
        public string OAuthTokenSecret { get; set; }
    }
}