using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoBlogAPI.Data;
using DemoBlogAPI.Models;

namespace DemoBlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BlogPostController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BlogPost
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPost>>> GetBlogs()
        {
          if (_context.Blogs == null)
          {
              return NotFound();
          }
            return await _context.Blogs.ToListAsync();
        }

        // GET: api/BlogPost/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPost>> GetBlogPost(int id)
        {
          if (_context.Blogs == null)
          {
              return NotFound();
          }
            var blogPost = await _context.Blogs.FindAsync(id);

            if (blogPost == null)
            {
                return NotFound();
            }

            return blogPost;
        }

        // PUT: api/BlogPost/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogPost(int id, BlogPost blogPost)
        {
            if (id != blogPost.BlogPostId)
            {
                return BadRequest();
            }

            _context.Entry(blogPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BlogPost
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BlogPost>> PostBlogPost(BlogPost blogPost)
        {
          if (_context.Blogs == null)
          {
              return Problem("Entity set 'AppDbContext.Blogs'  is null.");
          }
            _context.Blogs.Add(blogPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogPost", new { id = blogPost.BlogPostId }, blogPost);
        }

        // DELETE: api/BlogPost/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogPost(int id)
        {
            if (_context.Blogs == null)
            {
                return NotFound();
            }
            var blogPost = await _context.Blogs.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            _context.Blogs.Remove(blogPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogPostExists(int id)
        {
            return (_context.Blogs?.Any(e => e.BlogPostId == id)).GetValueOrDefault();
        }
    }
}
