using Microsoft.AspNetCore.Identity;

//might need to remove (Bhrugen)
namespace VinylTap.Models
{
    public class ApplicationUser : IdentityUser
    {
        //keep working this with the Bhrugen vid - delete migrations?
        public string User { get; set; }
    }
}