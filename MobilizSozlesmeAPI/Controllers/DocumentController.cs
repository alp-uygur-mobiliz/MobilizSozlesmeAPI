using Microsoft.AspNetCore.Mvc;

namespace MobilizSozlesmeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly ILogger<DocumentController> _logger;
        private IConfiguration _configuration;
        public DocumentController(IConfiguration configuration, ILogger<DocumentController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        private bool ControlToken(string token)
        {
            bool isValid = false;

            if (!string.IsNullOrEmpty(token))
            {
                string? techSignToken = _configuration.GetValue<string>("Tokens:TechSignToken");
                if (techSignToken.Equals(token))
                {
                    isValid = true;
                }

            }
            return isValid;
        }

        [HttpGet(Name = "DocumentSigned")]
        public IActionResult DocumentSigned([FromHeader] string token, [FromQuery] string documentId)
        {
            bool isTokenValid = ControlToken(token);
            if (!isTokenValid)
            {
                return Unauthorized("Token is not valid");
            }

            _ = TechSignAPI.GetDocumentAsync(documentId);

            return Ok("Document read");
        }

    }
}
