using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace VinylTap.Models
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(UserEmailAddress), IsUnique = true)]
    public class UserUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string UserFirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string UserLastName { get; set; }
        [Required]
        [EmailAddress]
        public string UserEmailAddress { get; set; }
        public string UserOldPasswordHash { get; set; }
        public string UserOldTempPassword { get; set; }
        public string UserNewPasswordHash { get; set; }
        public string UserNewTempPassword { get; set; }
        public string? UserProfileImage { get; set; }
        public string? UserBio { get; set; }
        public DateTime UserDateModified { get; set; }
    }
}