using Microsoft.AspNetCore.Mvc;
using VinylTap.ClientApp.Data;
using VinylTap.Models;

namespace VinylTap.Controllers
{
    [Route("api/configuration")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private readonly ILogger<ConfigurationsController> _logger;
        private readonly AlbumDbContext _context;

        public ConfigurationsController(ILogger<ConfigurationsController> logger, AlbumDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SaveConfiguration([FromBody] ConfigurationModel configuration)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var configEntity = new ConfigurationEntity 
            {
                ConsumerKey = configuration.ConsumerKey,
                ConsumerSecret = configuration.ConsumerSecret,
                OAuthToken = configuration.OAuthToken,
                OAuthTokenSecret = configuration.OAuthTokenSecret
            };

            _context.Configurations.Add(configEntity);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}