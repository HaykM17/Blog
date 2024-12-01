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

            modelBuilder.Entity<Blog>().HasMany(b => b.Posts)    
                              .WithOne(p => p.Blog)             
                              .HasForeignKey(p => p.BlogId)     
                              .OnDelete(DeleteBehavior.Cascade);        
        }


        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags {  get; set; } 
















    }
}
