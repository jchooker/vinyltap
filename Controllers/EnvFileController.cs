using Microsoft.AspNetCore.Mvc;

namespace VinylTap.Controllers
{
    [ApiController]
    [Route("api/envfile")]
    public class EnvFileController : ControllerBase
    {
        [HttpGet]
        public IActionResult CheckEnvFile() {
            var envFilePath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
            bool isEnvFileAvailable = System.IO.File.Exists(envFilePath);

            return Ok(new { isEnvFileAvailable });
        }
    }
}