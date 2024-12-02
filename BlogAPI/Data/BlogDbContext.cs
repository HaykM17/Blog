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

        public DbSet<Tag> Tags { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Blog>().HasMany(b => b.Posts)
                              .WithOne(p => p.Blog)
                              .HasForeignKey(p => p.BlogId)
                              .OnDelete(DeleteBehavior.SetNull);
                              //.OnDelete(DeleteBehavior.Cascade);




            // For Soft Delete Blog
            modelBuilder.Entity<Blog>().HasQueryFilter(b => !b.IsDeleted);

            // For Soft Delete Post
            modelBuilder.Entity<Post>().HasQueryFilter(p => !p.IsDeleted);

            // For Soft Delete Tag
            modelBuilder.Entity<Tag>().HasQueryFilter(t => !t.IsDeleted);



        }





        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Deleted)
                {
                    if (entry.Entity is Blog blog)
                    {
                        entry.State = EntityState.Modified;
                        blog.IsDeleted = true;
                    }
                    else if (entry.Entity is Post post)
                    {
                        entry.State = EntityState.Modified;
                        post.IsDeleted = true;
                    }
                    else if (entry.Entity is Tag tag)
                    {
                        entry.State = EntityState.Modified;
                        tag.IsDeleted = true;
                    }
                }
            }

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Deleted)
                {
                    if (entry.Entity is Blog blog)
                    {
                        entry.State = EntityState.Modified;
                        blog.IsDeleted = true;
                    }
                    else if (entry.Entity is Post post)
                    {
                        entry.State = EntityState.Modified;
                        post.IsDeleted = true;
                    }
                    else if (entry.Entity is Tag tag)
                    {
                        entry.State = EntityState.Modified;
                        tag.IsDeleted = true;
                    }
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }











    }
}
