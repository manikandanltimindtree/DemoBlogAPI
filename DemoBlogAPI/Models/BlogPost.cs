using System.ComponentModel.DataAnnotations;

namespace DemoBlogAPI.Models
{
    public class BlogPost
    {
        [Key]
        public int BlogPostId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public List<Comment>? Comments { get; set; }
    }
}
