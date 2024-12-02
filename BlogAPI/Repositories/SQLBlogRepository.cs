using BlogAPI.Data;
using BlogAPI.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BlogAPI.Repositories
{
    public class SQLBlogRepository : IBlogRepository
    {
        private readonly BlogDbContext dbContext;

        public SQLBlogRepository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }




        // Create
        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
            await dbContext.Blogs.AddAsync(blog);
            await dbContext.SaveChangesAsync();
            return blog;
        }

      


        // GetAll
        public async Task<List<Blog>> GetAllAsync()
        {
            return await dbContext.Blogs.Include(b=>b.Posts).ThenInclude(p=>p.Tags).ToListAsync();        
        }

        


        // GetById
        public async Task<Blog?> GetByIdAsync(Guid id)
        {
            return await dbContext.Blogs.Include(b=>b.Posts).ThenInclude(p=>p.Tags).FirstOrDefaultAsync(b=>b.BlogId == id);
        }



       
        // Update
        public async Task<Blog?> UpdateBlogAsync(Guid id,Blog blog)
        {
            var existingBlog = await dbContext.Blogs.FirstOrDefaultAsync(b=>b.BlogId == id);

            if (existingBlog == null)
            {
                return null;
            }

            existingBlog.Url = blog.Url;
            await dbContext.SaveChangesAsync();

            return existingBlog;
        }




        // Delete

        public async Task<Blog?> DeleteAsync(Guid id)
        {
            var existingBlog = dbContext.Blogs.FirstOrDefault(b => b.BlogId == id);
            if (existingBlog == null)
            {
                return null;
            }
            dbContext.Blogs.Remove(existingBlog);
            await dbContext.SaveChangesAsync();
            return existingBlog;
        }







        // For Restore Blog Soft Deleted Records

        public async Task<Blog?> RestoreBlogAsync(Guid blogId)
        {
            var blog = await dbContext.Blogs.IgnoreQueryFilters().FirstOrDefaultAsync(b => b.BlogId == blogId);

            if (blog == null)
            {
                return null;
            }

            blog.IsDeleted = false;
            await dbContext.SaveChangesAsync();

            return blog;
        }












    }
}
