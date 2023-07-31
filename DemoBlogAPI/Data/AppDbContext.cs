using DemoBlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoBlogAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<BlogPost> Blogs { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
