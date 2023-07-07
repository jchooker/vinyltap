using Microsoft.AspNetCore.Mvc;
using OAuth;
using Flurl.Http;
using VinylTap.Extensions;
using System.Net.Http.Headers;

namespace VinylTap.Controllers
{
    [ApiController]
    [Route("api")]
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

        [HttpGet("search/{query}")]
        public async Task<IActionResult> GeneralSearch([FromBody]string query)
        {
            // var response = await _httpClient.GetAsync($"/database/search?query={query}");
            var requestUrl =  _apiBaseUrl + $"database/search?query={query}";

            var _client = new HttpClient();
            var _request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

            _request.Headers.Add("User-Agent", "VinylTap 0.1");
            Int32 unixTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            string nonce = RandomNonce.FormNonce(); //tried all of this as a completely different kind of request
            var consumerKey = _configuration["CONSUMER_KEY"]; //...so it seems as thought the routing might be the
            var consumerSecret = _configuration["CONSUMER_SECRET"]; //problem bc I'm getting a similar looking 404
            var oauthToken = _configuration["OAUTH_TOKEN"];
            var oauthTokenSecret = _configuration["OAUTH_TOKEN_SECRET"];
            _request.Headers.Add("Authorization", $"OAuth oauth_consumer_key=\"{consumerKey}\",oauth_token=\"{oauthToken}\",oauth_signature_method=\"PLAINTEXT\",oauth_timestamp=\"{unixTimestamp}\",oauth_nonce=\"{nonce}\",oauth_version=\"1.0\",oauth_signature=\"{consumerSecret}%26{oauthTokenSecret}\"");

            _request.Headers.Add("Cookie", "__cf_bm=bsXjwChVzPC2ri5USDymMFeQnjWTe.8tD.Gfts82bKo-1688685685-0-Af856wM/p8NnGTIeDzuLvBl4pL87FuaX2doGwpd56V9ePkRtG1fhlyG7DCi3ej+gv5tED9hIUjWQo3Iaxn0o+U8=");


            // var client = new OAuthRequest
            // {
            //     Method = "GET",
            //     Type = OAuthRequestType.ProtectedResource,
            //     SignatureMethod = OAuthSignatureMethod.PlainText,
            //     ConsumerKey = _configuration["CONSUMER_KEY"],
            //     ConsumerSecret = _configuration["CONSUMER_SECRET"],
            //     Token = _configuration["OAUTH_TOKEN"],
            //     TokenSecret = _configuration["OAUTH_TOKEN_SECRET"],
            //     RequestUrl = requestUrl,
            // };
            // Console.WriteLine(client.GetAuthorizationQuery());
            // var url = client.RequestUrl + client.GetAuthorizationQuery();
            // var result = await url.GetStringAsync();
            var content = new StringContent(string.Empty);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            _request.Content = content;
            var response = await _client.SendAsync(_request);
            response.EnsureSuccessStatusCode();
            return Ok(response);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}