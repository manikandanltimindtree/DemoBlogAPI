using DemoBlogAPI.Data;
using DemoBlogAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoBlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {

        private readonly AppDbContext _context;

        public BlogPostsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]

        public async Task<IActionResult> PostBlogPost([FromBody] BlogPost blogPost)
        {
            try
            {
                if (blogPost == null)
                {
                    return BadRequest("Invalid blog post data.");
                }

                await _context.Blogs.AddAsync(blogPost);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetBlogPost), new { id = blogPost.BlogPostId }, blogPost);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("{blogPostId}/comments")]
        public async Task<IActionResult> PostComment(int blogPostId, [FromBody] Comment comment)
        {
            try
            {
                if (comment == null)
                {
                    return BadRequest("Invalid comment data.");
                }

                var blogPost = await _context.Blogs.FindAsync(blogPostId);
                if (blogPost == null)
                {
                    return NotFound("Blog post not found");
                }

                comment.BlogPostId = blogPostId;
                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetComment), new { id = comment.CommentId }, comment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured: {ex.Message}");
            }
        }

        private async Task<BlogPost> GetBlogPost(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            return blog;
        }

        private async Task<Comment> GetComment(int id)
        {
            return await _context.Comments.FindAsync(id);
        }
    }
}
