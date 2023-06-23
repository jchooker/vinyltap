
namespace VinylTap.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserAlias { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmailAddress { get; set; }
        public string UserPassword { get; set; }
        public string? UserProfileImage { get; set; }
        public string? UserBio { get; set; }
    }
}