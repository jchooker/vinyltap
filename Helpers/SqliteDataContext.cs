namespace VinylTap.Helpers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class SqliteDataContext : UserDbContext
{
    private readonly IConfiguration _configuration;
    public SqliteDataContext(IConfiguration configuration) : base(configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(_configuration.GetConnectionString("UserConnection"));
    }
}
