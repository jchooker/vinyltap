using Microsoft.EntityFrameworkCore;
using VinylTap.Extensions;
using System.Reflection;
//using OAuth;
using VinylTap.ClientApp.Data;

var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

var builder = WebApplication.CreateBuilder(args);

// builder.Configuration.Sources.Clear();

builder.Configuration
    .AddUserSecrets(Assembly.GetEntryAssembly()!)
    .AddEnvironmentVariables()
    .AddDotEnvFile();

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AlbumContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "OAuth";
    options.DefaultChallengeScheme = "OAuth";
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowAll");

app.UseEndpoints(endpoints => {
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
    name: "api",
    pattern: "{controller}/{action}/{query?}");
});

app.MapFallbackToFile("index.html");


app.Run();
