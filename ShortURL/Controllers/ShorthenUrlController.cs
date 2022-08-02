using Microsoft.AspNetCore.Mvc;
using ShortURL.Services;
using System.Text;

namespace ShortURL.Controllers
{
    [ApiController]
    [Route("/")]
    public class ShortenUrlController : ControllerBase
    {
        static int counter = 0;
        private readonly UrlsDbService _urlsService;
        public ShortenUrlController(UrlsDbService urlsService) => _urlsService = urlsService;


        [HttpPut(Name = "PutShortUrl")]
        public async Task<string> PutShortUrl(string url)
        {
            counter += 1;
            string shortUrl = Convert.ToBase64String(Encoding.UTF8.GetBytes(counter.ToString()));
            // store the short url in the DB
            await _urlsService.CreateAsync(new Models.ShortUrlUser { longUrl = url, shortUrl = shortUrl}) ;

            return "https://localhost:7212?shortUrlDomain=" + shortUrl;
        }

        [HttpGet(Name = "{shortUrlDomain}")]
        public async Task RedirectShortUrl(string shortUrlDomain)
        {
            var res = await _urlsService.GetAsync(shortUrlDomain);
            string longUrl = res.longUrl;
            Response.Redirect(longUrl);
        }
    }
}