using analytics.Models;
using Microsoft.AspNetCore.Mvc;

namespace analytics.Interfaces
{
    public interface IAnalyticsService
    {
        Task<ActionResult<IEnumerable<Path_PageViews>>> GetData(int page, int pageSize);
        Task<ActionResult<IEnumerable<Path_PageViews>>> GetData();
    }
}