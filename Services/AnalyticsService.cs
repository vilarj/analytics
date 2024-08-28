using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using analytics.Context;
using analytics.Interfaces;
using analytics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace analytics.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly AnalyticsContext _context;
        private readonly ILogger<AnalyticsService> _logger;
        public AnalyticsService(AnalyticsContext context, ILogger<AnalyticsService> logger) {
            _context = context;
            _logger = logger;
        }

        public async Task<ActionResult<IEnumerable<Path_PageViews>>> GetData(int page, int pageSize)
        {
            return await _context.Path_PageViews
            .AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(e => new Path_PageViews
            {
                page_title = e.page_title,
                domain = e.domain,
                page_path = e.page_path,
                pageviews = e.pageviews
            })
            .ToListAsync();
        }

        public async Task<ActionResult<IEnumerable<Path_PageViews>>> GetData()
        {
            return await _context.Path_PageViews
            .AsNoTracking()
            .Select(e => new Path_PageViews
            {
                page_title = e.page_title,
                domain = e.domain,
                page_path = e.page_path,
                pageviews = e.pageviews
            })
            .ToListAsync();
        }
    }
}