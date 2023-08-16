using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
//might need to remove (Bhrugen)
namespace VinylTap.Models
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(EmailAddress), IsUnique = true)]
    public class UserCreateDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public string? UserProfileImage { get; set; }
        public string? UserBio { get; set; }
        public static DateTime UserDateCreated { get; set; }
    }
}