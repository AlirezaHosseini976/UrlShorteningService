using Microsoft.AspNetCore.Mvc;
using Service.Utilities;
using ServiceContracts.Contracts;

namespace UrlShorteningService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortenUrlController : Controller
    {
        private readonly IUrlManagementService _urlManagementService;

        public ShortenUrlController(IUrlManagementService urlManagementService)
        {
            _urlManagementService = urlManagementService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateNewShortenUrlAsync([FromBody] string originalUrl,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(originalUrl))
            {
                throw new ArgumentException("The provided Url is invalid!", originalUrl);
            }
            var shortUrl = await _urlManagementService.CreateShortenedUrlAsync(originalUrl, cancellationToken);
            return Ok(shortUrl);
        }

    }
}


