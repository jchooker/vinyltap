namespace VinylTap.Services;

using AutoMapper;
using BCrypt.Net;
using VinylTap.Entities;
using VinylTap.Models.Users;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(int id);
    void Register(RegisterRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
}