using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Web.Http;
using VinylTap.Data;
using VinylTap.Models;
//using VinylTap.Models.Dto;
using bc = BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace VinylTap.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserDbContext _db;
        private readonly IConfiguration _configuration;
        public UsersController(UserDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet("all")]
        public async Task<IEnumerable<UserDTO>> GetUsersAsync() {
            return UserStore.userList;
        }
        [Microsoft.AspNetCore.Mvc.HttpPost("register")]
        public IActionResult Register(User user) //Merge completely with CreateUser?
        {
            if(_db.Users.Any(u => u.Username == user.Username)) 
            {
                return BadRequest("Username already exists");            
            }

            _db.Users.Add(user);
            _db.SaveChanges();

            return Ok("User registered successfully");
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUserAsync([Microsoft.AspNetCore.Mvc.FromBody] UserCreateDTO userDTO) {
            if(_db.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == userDTO.Username.ToLower()) != null) {
                ModelState.AddModelError("CustomError", "Username already exists");
                return BadRequest(ModelState);
            }
            if(userDTO == null) return BadRequest(userDTO);

            string hashedPassword = bc.HashPassword(userDTO.UserOldTempPassword);
            userDTO.UserOldPasswordHash = hashedPassword;

            User model = new() {
                Username = userDTO.Username,
                UserFirstName = userDTO.UserFirstName,
                UserLastName = userDTO.UserLastName,
                UserEmailAddress = userDTO.UserEmailAddress,
                UserOldPasswordHash = userDTO.UserOldPasswordHash,
                UserOldTempPassword = userDTO.UserOldTempPassword,
                UserProfileImage = userDTO.UserProfileImage,
                UserBio = userDTO.UserBio,
                UserDateCreated = DateTime.Now
            };
            await _db.Users.AddAsync(model);
            await _db.SaveChangesAsync();
            return CreatedAtRoute("GetUser", new { id = model.Id }, model);
            }

        [Microsoft.AspNetCore.Mvc.HttpPut("{id:int}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUserAsync(int id, [Microsoft.AspNetCore.Mvc.FromBody] UserUpdateDTO userDTO) {
            if (userDTO == null || id != userDTO.Id) return BadRequest();
            User model = new () { //conversion takes place here
                Username = userDTO.Username,
                UserFirstName = userDTO.UserFirstName,
                UserLastName = userDTO.UserLastName,
                UserEmailAddress = userDTO.UserEmailAddress,
                // UserOldPasswordHash = userDTO.UserOldPasswordHash,
                // UserOldTempPassword = userDTO.UserOldTempPassword,
                // UserNewPasswordHash = userDTO.UserNewPasswordHash,
                // UserNewTempPassword = userDTO.UserNewTempPassword,
                UserProfileImage = userDTO.UserProfileImage,
                UserBio = userDTO.UserBio,
                UserDateModified = DateTime.Now
            };
            _db.Users.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [Microsoft.AspNetCore.Mvc.HttpPatch("{id:int}", Name = "UpdatePartialUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialUserAsync(int id, JsonPatchDocument<UserUpdateDTO> patchDTO) {

            if (patchDTO == null || id == 0) return BadRequest();

            var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            UserUpdateDTO userDTO = new () { //conversion takes place here
                Username = user.Username,
                UserFirstName = user.UserFirstName,
                UserLastName = user.UserLastName,
                UserEmailAddress = user.UserEmailAddress,
                // UserOldPasswordHash = userDTO.UserOldPasswordHash,
                // UserOldTempPassword = userDTO.UserOldTempPassword,
                // UserNewPasswordHash = userDTO.UserNewPasswordHash,
                // UserNewTempPassword = userDTO.UserNewTempPassword,
                UserProfileImage = user.UserProfileImage,
                UserBio = user.UserBio,
                UserDateModified = DateTime.Now
            };

            if (user == null) return BadRequest();

            patchDTO.ApplyTo(userDTO, ModelState);
            User model = new () {
                Username = userDTO.Username,
                UserFirstName = userDTO.UserFirstName,
                UserLastName = userDTO.UserLastName,
                UserEmailAddress = userDTO.UserEmailAddress,
                // UserOldPasswordHash = userDTO.UserOldPasswordHash,
                // UserOldTempPassword = userDTO.UserOldTempPassword,
                // UserNewPasswordHash = userDTO.UserNewPasswordHash,
                // UserNewTempPassword = userDTO.UserNewTempPassword,
                UserProfileImage = userDTO.UserProfileImage,
                UserBio = userDTO.UserBio,
                UserDateModified = DateTime.Now
            };
            _db.Users.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [Microsoft.AspNetCore.Mvc.HttpPatch("{id:int}/pw", Name = "UpdateUserPassword")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUserPasswordAsync(int id, JsonPatchDocument<UserUpdateDTO> userPasswordDTO) {
            if (userPasswordDTO == null || id != 0) return BadRequest();
            var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            UserUpdateDTO userDTO = new () { //conversion takes place here
                // UserOldPasswordHash = userDTO.UserOldPasswordHash,
                // UserOldTempPassword = userDTO.UserOldTempPassword,
                // UserNewPasswordHash = userDTO.UserNewPasswordHash,
                // UserNewTempPassword = userDTO.UserNewTempPassword,
                UserDateModified = DateTime.Now
            };
            
            if (user == null) return BadRequest();

            userPasswordDTO.ApplyTo(userDTO, ModelState);
            User model = new () {
                // UserOldPasswordHash = userDTO.UserOldPasswordHash,
                // UserOldTempPassword = userDTO.UserOldTempPassword,
                // UserNewPasswordHash = userDTO.UserNewPasswordHash,
                // UserNewTempPassword = userDTO.UserNewTempPassword,
                UserDateModified = DateTime.Now
            };
            _db.Users.Update(model);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Microsoft.AspNetCore.Mvc.HttpPost("login")]
        public async Task<IActionResult> LoginAsync(User user) 
        {
            var existingUser = await _db.Users.SingleOrDefaultAsync(u => u.Username == user.Username);

            if (existingUser == null || existingUser.UserNewPasswordHash != user.UserNewPasswordHash)
            {
                return BadRequest("Invalid credentials");
            }

            return Ok("Login successful");
        }
    }
}