/*using ShortURL.Models;
using ShortURL.Services;
using Microsoft.AspNetCore.Mvc;

namespace ShortURL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlsController : Controller
    {
        private readonly UrlsService _urlsService;
        public UrlsController(UrlsService urlsService) => _urlsService = urlsService;

        [HttpGet]
        public async Task<List<TinyUrlUser>> Get() => await _urlsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<TinyUrlUser>> Get(string id)
        {
            var url = await _urlsService.GetAsync(id);

            if (url is null)
            {
                return NotFound();
            }

            return url;
        }
        [HttpPost]
        public async Task<IActionResult> Post(TinyUrlUser newUser)
        {
            await _urlsService.CreateAsync(newUser);

            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, TinyUrlUser updatedUrl)
        {
            var url = await _urlsService.GetAsync(id);

            if (url is null)
            {
                return NotFound();
            }

            updatedUrl.Id = url.Id;

            await _urlsService.UpdateAsync(id, updatedUrl);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var url = await _urlsService.GetAsync(id);

            if (url is null)
            {
                return NotFound();
            }

            await _urlsService.RemoveAsync(id);

            return NoContent();
        }

    }
}
*/