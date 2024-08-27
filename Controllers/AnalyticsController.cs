using analytics.Context;
using analytics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace analytics.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalyticsController : ControllerBase
    {
        private readonly AnalyticsContext _context;
        private readonly ILogger<AnalyticsController> _logger;

        public AnalyticsController(AnalyticsContext context, ILogger<AnalyticsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("/api/GetData")]
        public async Task<IEnumerable<Path_PageViews>> GetData()
        {
            return await _context.Path_PageViews.Select(e => new Path_PageViews
            {
                page_title = e.page_title,
                domain = e.domain,
                page_path = e.page_path,
                pageviews = e.pageviews
            }).ToListAsync();
        }
    }
}
