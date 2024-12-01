using BlogAPI.Data;
using BlogAPI.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repositories
{
    public class SQLBlogRepository : IBlogRepository
    {
        private readonly BlogDbContext dbContext;

        public SQLBlogRepository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }





        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
            await dbContext.Blogs.AddAsync(blog);
            await dbContext.SaveChangesAsync();
            return blog;
        }

      



        public async Task<List<Blog>> GetAllAsync()
        {
            return await dbContext.Blogs.Include(b=>b.Posts).ThenInclude(p=>p.Tags).ToListAsync();        
        }

        



        public async Task<Blog?> GetByIdAsync(Guid id)
        {
            return await dbContext.Blogs.Include(b=>b.Posts).ThenInclude(p=>p.Tags).FirstOrDefaultAsync(b=>b.BlogId == id);
        }

       

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




        public async Task<Blog?> DeleteAsync(Guid id)
        {
            var existingBlog = dbContext.Blogs.FirstOrDefault(i => i.BlogId == id);
            if (existingBlog == null)
            {
                return null;
            }
            dbContext.Blogs.Remove(existingBlog);
            await dbContext.SaveChangesAsync();
            return existingBlog;
        }










    }
}
