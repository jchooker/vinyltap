using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
//might need to remove (Bhrugen)
namespace VinylTap.Models
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(EmailAddress), IsUnique = true)]
    public class UserUpdateDTO
    {
        [Required]
        public int Id { get; set; }
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
        public string? ProfileImage { get; set; }
        public string? Bio { get; set; }
        public DateTime DateModified { get; set; }
    }
}