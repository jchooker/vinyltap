using Microsoft.EntityFrameworkCore;
using VinylTap.Extensions;
using System.Reflection;
//using OAuth;
using VinylTap.ClientApp.Data;
using VinylTap.Data;
//using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using VinylTap.Authorization;
using VinylTap.Helpers;
using VinylTap.Authorization.IAuthorization;
using VinylTap.Services;

var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

var builder = WebApplication.CreateBuilder(args);
var miscKeys = builder.Configuration["AppSettings:Secret"];

var services = builder.Services;

services.AddCors(options => 
{ 
    options.AddPolicy("CorsPolicy", builder => {
        builder.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .WithOrigins("https://localhost:7091", "https://localhost:44413");
    });
});
// builder.Configuration.Sources.Clear();

builder.Configuration
    .AddUserSecrets(Assembly.GetEntryAssembly()!)
    .AddEnvironmentVariables()
    .AddDotEnvFile();

// Add services to the container.

//builder.Services.AddControllersWithViews();
services.AddControllers();

services.AddAutoMapper(typeof(Program));

services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

services.AddScoped<IJwtUtils, JwtUtils>();
services.AddScoped<IUserService, UserService>();

services.AddDbContext<AlbumDbContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("AlbumConnection"));
});
services.AddDbContext<UserDbContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("UserConnection"));
});


//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//    .AddEntityFrameworkStores<UserDbContext>();

//builder.Services.Configure<IdentityOptions>(options =>
//{
//    // Default Password settings.
//    options.Password.RequireDigit = true;
//    options.Password.RequireLowercase = true;
//    options.Password.RequireNonAlphanumeric = true;
//    options.Password.RequireUppercase = true;
//    options.Password.RequiredLength = 6;
//    options.Password.RequiredUniqueChars = 1;
//});

//*********^^^REMOVING IDENTITY SERVICE ENTIRELY??

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = "OAuth";
//    options.DefaultChallengeScheme = "OAuth";
//});
//v2: both jwt and oauth 1.0a authentication (below)
services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "OAuth";
    options.DefaultChallengeScheme = "OAuth";
});
var key = Encoding.ASCII.GetBytes("your-secret-key"); // Replace this with a secure secret key.
services.AddAuthentication()
    .AddCookie(options =>
    {
        options.LoginPath = "/auth/unauthorized";
        options.AccessDeniedPath = "/auth/forbidden";
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
//var key = Encoding.ASCII.GetBytes("your-secret-key"); // Replace this with a secure secret key.
//builder.Services.AddAuthentication("JwtBearer")
//    .AddJwtBearer("JwtBearer", options =>
//    {
//        options.RequireHttpsMetadata = false;
//        options.SaveToken = true;
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(key),
//            ValidateIssuer = false,
//            ValidateAudience = false
//        };
//    });
//above is orig version w/ addjwtbearer error
services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseCors("CorsPolicy");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.UseMiddleware<ErrorHandlerMiddleware>();
//^^assuming I want to keep custom global error handling

app.UseMiddleware<JwtMiddleware>();

// app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// app.MapControllerRoute(
//     name: "api",
//     pattern: "{controller}/{action}/{query?}");

app.MapFallbackToFile("index.html");


app.Run();
