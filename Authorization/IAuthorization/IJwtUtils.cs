namespace VinylTap.Authorization.IAuthorization;

using Microsoft.Extensions.Options;
using VinylTap.Entities;
using VinylTap.Helpers;

public interface IJwtUtils
{
    public string GenerateToken(User user, IOptions<AppSettings> appSettings);
    public int? ValidateToken(string token, IOptions<AppSettings> appSettings);
}
