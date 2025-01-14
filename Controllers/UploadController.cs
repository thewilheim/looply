using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using looply.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace looply.Controllers
{
    [Route("api/v1/[controller]")]
    public class UploadController : Controller
    {
        private readonly ILogger<UploadController> _logger;
        private readonly IBlobService _blobService;

        public UploadController(ILogger<UploadController> logger, IBlobService blobService)
        {
            _logger = logger;
            _blobService = blobService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Upload(IFormFile file)
        {

            string[] supportedFileTypes = new[] {"image/jpg","image/jpeg","image/png", "video/mp3", "video/mov","video/quicktime"};

            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            if (!file.ContentType.StartsWith("image/") && !file.ContentType.StartsWith("video/"))
            {
                return BadRequest("Only images and videos  are allowed.");
            }

            if(!supportedFileTypes.Contains(file.ContentType)) return BadRequest("Invalid content type");

            if (file.Length > 100 * 1024 * 1024) // 100 MB
            {
                return BadRequest("File size exceeds the limit.");
            }

            using Stream stream = file.OpenReadStream();

            Uri fileUri = await _blobService.UploadAsync(stream, file.ContentType);

            return Ok(new { FileName = file.FileName, FilePath = fileUri });
        }
    }
}