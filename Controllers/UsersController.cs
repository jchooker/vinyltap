using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using VinylTap.Entities;
//using VinylTap.Models.Dto;
//using bc = BCrypt.Net.BCrypt;
//using Microsoft.AspNetCore.JsonPatch;
//using Microsoft.EntityFrameworkCore;
using VinylTap.Services;
using AutoMapper;
using Microsoft.Extensions.Options;
using VinylTap.Helpers;
using VinylTap.Models.Users;

namespace VinylTap.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("users")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        //private readonly UserDbContext _db;
        //private readonly IConfiguration _configuration;
        //public UsersController(UserDbContext db, IConfiguration configuration)
        public UsersController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            //_db = db;
            //_configuration = configuration;
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [Microsoft.AspNetCore.Mvc.HttpPost("auth")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            return Ok(response);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("allusers")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
        //public async Task<IActionResult> GetUsersAsync() {
        //    return UserStore.userList;
        //}

        [Microsoft.AspNetCore.Mvc.HttpGet("user/{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [AllowAnonymous]
        [Microsoft.AspNetCore.Mvc.HttpPost("register")]
        public IActionResult Register(RegisterRequest model)
        {
            _userService.Register(model);
            return Ok(new {message = "Successfully registered."});
        }

        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRequest model)
        {
            _userService.Update(id, model);
            return Ok(new { message = "User successfully updated." });
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok(new { message = "User successfully deleted." });
        }

        //public IActionResult Register(User user) //Merge completely with CreateUser?
        //{
        //    if(_db.Users.Any(u => u.Username == user.Username)) 
        //    {
        //        return BadRequest("Username already exists");            
        //    }

        //    _db.Users.Add(user);
        //    _db.SaveChanges();

        //    return Ok("User registered successfully");
        //}

        //[Microsoft.AspNetCore.Mvc.HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> CreateUserAsync([Microsoft.AspNetCore.Mvc.FromBody] UserCreateDTO userDTO) {
        //    if(_db.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == userDTO.Username.ToLower()) != null) {
        //        ModelState.AddModelError("CustomError", "Username already exists");
        //        return BadRequest(ModelState);
        //    }
        //    if(userDTO == null) return BadRequest(userDTO);

        //    string hashedPassword = bc.HashPassword(userDTO.UserOldTempPassword);
        //    userDTO.UserOldPasswordHash = hashedPassword;

        //    User model = new() {
        //        Username = userDTO.Username,
        //        UserFirstName = userDTO.UserFirstName,
        //        UserLastName = userDTO.UserLastName,
        //        UserEmailAddress = userDTO.UserEmailAddress,
        //        UserOldPasswordHash = userDTO.UserOldPasswordHash,
        //        UserOldTempPassword = userDTO.UserOldTempPassword,
        //        UserProfileImage = userDTO.UserProfileImage,
        //        UserBio = userDTO.UserBio,
        //        UserDateCreated = DateTime.Now
        //    };
        //    await _db.Users.AddAsync(model);
        //    await _db.SaveChangesAsync();
        //    return CreatedAtRoute("GetUser", new { id = model.Id }, model);
        //    }

        //[Microsoft.AspNetCore.Mvc.HttpPut("{id:int}", Name = "UpdateUser")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> UpdateUserAsync(int id, [Microsoft.AspNetCore.Mvc.FromBody] UserUpdateDTO userDTO) {
        //    if (userDTO == null || id != userDTO.Id) return BadRequest();
        //    User model = new () { //conversion takes place here
        //        Username = userDTO.Username,
        //        UserFirstName = userDTO.UserFirstName,
        //        UserLastName = userDTO.UserLastName,
        //        UserEmailAddress = userDTO.UserEmailAddress,
        //ALREADY REMOVED** UserOldPasswordHash = userDTO.UserOldPasswordHash,
        //ALREADY REMOVED** UserOldTempPassword = userDTO.UserOldTempPassword,
        //ALREADY REMOVED** UserNewPasswordHash = userDTO.UserNewPasswordHash,
        //ALREADY REMOVED** UserNewTempPassword = userDTO.UserNewTempPassword,
        //UserProfileImage = userDTO.UserProfileImage,
        //        UserBio = userDTO.UserBio,
        //        UserDateModified = DateTime.Now
        //    };
        //    _db.Users.Update(model);
        //    await _db.SaveChangesAsync();
        //    return NoContent();
        //}

        //[Microsoft.AspNetCore.Mvc.HttpPatch("{id:int}", Name = "UpdatePartialUser")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> UpdatePartialUserAsync(int id, JsonPatchDocument<UserUpdateDTO> patchDTO) {

        //    if (patchDTO == null || id == 0) return BadRequest();

        //    var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        //    UserUpdateDTO userDTO = new () { //conversion takes place here
        //        Username = user.Username,
        //        UserFirstName = user.UserFirstName,
        //        UserLastName = user.UserLastName,
        //        UserEmailAddress = user.UserEmailAddress,
                //ALREADY REMOVED** UserOldPasswordHash = userDTO.UserOldPasswordHash,
                //ALREADY REMOVED** UserOldTempPassword = userDTO.UserOldTempPassword,
                //ALREADY REMOVED** UserNewPasswordHash = userDTO.UserNewPasswordHash,
                //ALREADY REMOVED** UserNewTempPassword = userDTO.UserNewTempPassword,
                //    UserProfileImage = user.UserProfileImage,
                //    UserBio = user.UserBio,
                //    UserDateModified = DateTime.Now
                //};

                //if (user == null) return BadRequest();

                //patchDTO.ApplyTo(userDTO, ModelState);
                //User model = new () {
                //    Username = userDTO.Username,
                //    UserFirstName = userDTO.UserFirstName,
                //    UserLastName = userDTO.UserLastName,
                //    UserEmailAddress = userDTO.UserEmailAddress,
                //ALREADY REMOVED** UserOldPasswordHash = userDTO.UserOldPasswordHash,
                //ALREADY REMOVED**UserOldTempPassword = userDTO.UserOldTempPassword,
                //ALREADY REMOVED** UserNewPasswordHash = userDTO.UserNewPasswordHash,
                //ALREADY REMOVED** UserNewTempPassword = userDTO.UserNewTempPassword,
                //        UserProfileImage = userDTO.UserProfileImage,
                //        UserBio = userDTO.UserBio,
                //        UserDateModified = DateTime.Now
                //    };
                //    _db.Users.Update(model);
                //    await _db.SaveChangesAsync();
                //    return NoContent();
                //}

                //[Microsoft.AspNetCore.Mvc.HttpPatch("{id:int}/pw", Name = "UpdateUserPassword")]
                //[ProducesResponseType(StatusCodes.Status204NoContent)]
                //[ProducesResponseType(StatusCodes.Status400BadRequest)]
                //public async Task<IActionResult> UpdateUserPasswordAsync(int id, JsonPatchDocument<UserUpdateDTO> userPasswordDTO) {
                //    if (userPasswordDTO == null || id != 0) return BadRequest();
                //    var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
                //    UserUpdateDTO userDTO = new () { //conversion takes place here
                //ALREADY REMOVED** UserOldPasswordHash = userDTO.UserOldPasswordHash,
                //ALREADY REMOVED** UserOldTempPassword = userDTO.UserOldTempPassword,
                //ALREADY REMOVED** UserNewPasswordHash = userDTO.UserNewPasswordHash,
                //ALREADY REMOVED** UserNewTempPassword = userDTO.UserNewTempPassword,
                //    UserDateModified = DateTime.Now
                //};

                //if (user == null) return BadRequest();

                //userPasswordDTO.ApplyTo(userDTO, ModelState);
                //User model = new () {
                //ALREADY REMOVED** UserOldPasswordHash = userDTO.UserOldPasswordHash,
                //ALREADY REMOVED** UserOldTempPassword = userDTO.UserOldTempPassword,
                //ALREADY REMOVED** UserNewPasswordHash = userDTO.UserNewPasswordHash,
                //ALREADY REMOVED** UserNewTempPassword = userDTO.UserNewTempPassword,
                //        UserDateModified = DateTime.Now
                //    };
                //    _db.Users.Update(model);
                //    await _db.SaveChangesAsync();
                //    return NoContent();
                //}

    //            [AllowAnonymous]
    //    [ValidateAntiForgeryToken]
    //    [Microsoft.AspNetCore.Mvc.HttpPost("login")]
    //    public async Task<IActionResult> LoginAsync(User user) 
    //    {
    //        var existingUser = await _db.Users.SingleOrDefaultAsync(u => u.Username == user.Username);

    //        if (existingUser == null || existingUser.UserNewPasswordHash != user.UserNewPasswordHash)
    //        {
    //            return BadRequest("Invalid credentials");
    //        }

    //        return Ok("Login successful");
    //    }
    //}
}