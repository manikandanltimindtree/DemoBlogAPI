using System.ComponentModel.DataAnnotations;

namespace DemoBlogAPI.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public string Content { get; set; } = string.Empty;

        public int BlogPostId { get; set; }

        public BlogPost? BlogPost { get; set; }
    }
}
