using VinylTap.Models;

namespace VinylTap.Data
{
    public static class UserStore
    {
        public static List<UserDTO> userList = new List<UserDTO>{
            new UserDTO {
                Id = 1,
                Username = "test",
                FirstName = "Joseph",
                LastName = "Test",
                EmailAddress = "test@testshop.com"
        }
        };
    }
}