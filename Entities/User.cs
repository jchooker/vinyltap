namespace VinylTap.Entities;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


[Index(nameof(Username), IsUnique = true)]
[Index(nameof(EmailAddress), IsUnique = true)]
public class User
{
    [Key]
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
    [JsonIgnore] //ji attribute prevents the PasswordHash property from being serialized and returned in api responses.
    public string PasswordHash {get; set;}
    public string? ProfileImage { get; set; }
    public string? Bio { get; set; }
    public static DateTime DateCreated { get; set; } = System.DateTime.Now;
    public DateTime? DateModified { get; set; }
}
