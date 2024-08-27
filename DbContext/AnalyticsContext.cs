using analytics.Models;
using Microsoft.EntityFrameworkCore;

namespace analytics.Context
{
    public class AnalyticsContext(DbContextOptions<AnalyticsContext> options) : DbContext(options)
    {
        public DbSet<Path_PageViews> Path_PageViews { get; set; }
    }
}