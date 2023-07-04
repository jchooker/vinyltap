using System.ComponentModel.DataAnnotations;

namespace VinylTap.Models
{
    public class ConfigurationModel
    {
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