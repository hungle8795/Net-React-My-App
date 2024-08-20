using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Net_React.Server.Controllers
{
    public class ValuesController : ControllerBase
    {
        private ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {

            _logger.LogInformation("Fetching all elements from the list.");

            var tList = new List<string>() { "John", "Doe", "123", "ABC123" };

            _logger.LogInformation($"Returning {tList.Count} elements.");

            return Ok(tList);

        }
    }
}
