using Microsoft.AspNetCore.Mvc;

namespace MobilizSozlesmeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotoristController : ControllerBase
    {
        private readonly ILogger<MotoristController> _logger;
        private IConfiguration _configuration;
        public MotoristController(IConfiguration configuration, ILogger<MotoristController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        private bool ControlToken(string token)
        {
            bool isValid = false;

            if (!string.IsNullOrEmpty(token))
            {
                string? motoristToken = _configuration.GetValue<string>("Tokens:MotoristToken");
                if (motoristToken.Equals(token))
                {
                    isValid = true;
                }

            }
            return isValid;
        }

        [HttpPost]
        [Route("documentSigned")]
        public IActionResult DocumentSigned([FromHeader] string token, [FromBody] SozlesmeTextFields sozlesme)
        {
            bool isTokenValid = ControlToken(token);
            if (!isTokenValid)
            {
                return Unauthorized("Token is not valid");
            }

            return Ok("Document read");
        }

        [HttpPost]
        [Route("sozlesmeFile")]
        public IActionResult SozlesmeFile([FromHeader] string token, IFormFile file)
        {
            bool isTokenValid = ControlToken(token);
            if (!isTokenValid)
            {
                return Unauthorized("Token is not valid");
            }

            string? FilePath = _configuration.GetValue<string>("SozlesmelerDosyası");

            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);

            var filePath = Path.Combine(FilePath, "FirmaAdı" + ".pdf");

            using (FileStream fs = System.IO.File.Create(filePath))
            {
                file.CopyTo(fs);
            }

            return Ok("File saved");
        }

    }
}
