using API.Standard.Controllers.Responses;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Handle()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionFeature != null)
            {
                var exception = exceptionFeature.Error;

                _logger.LogError($"{exception.Message} {exception.StackTrace}");
            }
                        
            return StatusCode(500, new ErrorsResponse(new []{"Internal server error"}));
        }
    }
}