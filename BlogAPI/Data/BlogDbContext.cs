using BlogAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Data
{
    public class BlogDbContext : DbContext
    {

        public BlogDbContext(DbContextOptions options) : base(options)
        {
            
        }



        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags {  get; set; } 
















    }
}
