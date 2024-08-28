using analytics.Interfaces;
using analytics.Models;
using Microsoft.AspNetCore.Mvc;

namespace analytics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalyticsController : ControllerBase
    {
        private readonly ILogger<AnalyticsController> _logger;
        private readonly IAnalyticsService _service;

        public AnalyticsController(IAnalyticsService service, ILogger<AnalyticsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("/api/GetData")]
        public async Task<ActionResult<IEnumerable<Path_PageViews>>> GetData(int page = 1, int pageSize = 10)
        {
            return await _service.GetData(page, pageSize);
        }
        
        [HttpGet("/api/GetAllData")]
        public async Task<ActionResult<IEnumerable<Path_PageViews>>> GetData()
        {
            return await _service.GetData();
        }
    }
}
