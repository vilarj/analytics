using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace analytics.Models
{
    [Table("path_pageviews")]
    public class Path_PageViews
    {
        [Key]
        public string? page_title { get; set; }
        public string? domain { get; set; }
        public string? page_path { get; set; }
        public int pageviews { get; set; }
    }
}