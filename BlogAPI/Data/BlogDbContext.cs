using BlogAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Data
{
    public class BlogDbContext : DbContext
    {

        public BlogDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Blog>().HasMany(b => b.Posts)    // Blog имеет много Post
                              .WithOne(p => p.Blog)     // У Post один Blog
                              .HasForeignKey(p => p.BlogId) // Внешний ключ в таблице Posts
                              .OnDelete(DeleteBehavior.Cascade); // Удаление постов при удалении блога        
        }


        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags {  get; set; } 
















    }
}
