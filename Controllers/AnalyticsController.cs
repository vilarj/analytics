using Microsoft.AspNetCore.Mvc;

namespace analytics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalyticsController : ControllerBase
    {

        private readonly ILogger<AnalyticsController> _logger;

        public AnalyticsController(ILogger<AnalyticsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/api/GetData")]
        public IEnumerable<int> Get()
        {
            return Enumerable.Range(1, 5).ToArray();
        }
    }
}
