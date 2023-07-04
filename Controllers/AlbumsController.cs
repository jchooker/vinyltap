using Microsoft.AspNetCore.Mvc;
using OAuth;
using Flurl.Http;

namespace VinylTap.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumsController : Controller
    {
        private static string _apiBaseUrl = "https://api.discogs.com/";
        private readonly IConfiguration _configuration;

        public AlbumsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            //var client = clientFactory.CreateClient("VinylTapAPI");
            //await client.GetAsync("api/albums");
            // string auth = oauthClient.GetAuthorizationHeader();
            // HttpWebRequest request = (HttpWebRequest) WebRequest.Create(oauthClient.RequestUrl);

            // request.Headers.Add("Authorization", auth);
            return View();
        }

        [HttpGet("search")]
        public async Task<IActionResult> GeneralSearch(string query)
        {
            // var response = await _httpClient.GetAsync($"/database/search?query={query}");
            var requestUrl =  _apiBaseUrl + $"database/search?query={query}";

            var client = new OAuthRequest
            {
                Method = "GET",
                Type = OAuthRequestType.ProtectedResource,
                SignatureMethod = OAuthSignatureMethod.PlainText,
                ConsumerKey = _configuration["CONSUMER_KEY"],
                ConsumerSecret = _configuration["CONSUMER_SECRET"],
                Token = _configuration["OAUTH_TOKEN"],
                TokenSecret = _configuration["OAUTH_TOKEN_SECRET"],
                RequestUrl = _apiBaseUrl + $"database/search?query={query}",
            };
            Console.WriteLine(client.GetAuthorizationQuery());
            var url = requestUrl + client.GetAuthorizationQuery();
            var result = await url.GetStringAsync();
            return Ok(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}