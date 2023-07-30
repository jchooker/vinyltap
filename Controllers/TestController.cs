using Microsoft.AspNetCore.Mvc;
using OAuth;
using Flurl.Http;
using VinylTap.Extensions;
using System.Net.Http.Headers;

namespace VinylTap.Controllers
{
    [ApiController]
    [Route("api/products")] 
    public class ProductsController : Controller 
    { 
        [HttpGet("search")] 
        public IActionResult Search([FromQuery] string query) 
        { 
            return Ok(new {test=query}); 
        } 
    } 
}