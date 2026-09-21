using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace BlogApi.Models
{
    public class BlogPost
    {
        public string Title { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime postTime { get; set; }

        public DateTime updateTime { get; set; }
        public int blogId { get; set; }
    }

}
