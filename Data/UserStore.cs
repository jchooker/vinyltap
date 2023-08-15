using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinylTap.Models;

namespace VinylTap.Data
{
    public static class UserStore
    {
        public static List<UserDTO> userList = new List<UserDTO>{
            new UserDTO {
                Id = 1,
                Username = "test",
                UserFirstName = "Joseph",
                UserLastName = "Test",
                UserEmailAddress = "test@testshop.com"
        }
        };
    }
}