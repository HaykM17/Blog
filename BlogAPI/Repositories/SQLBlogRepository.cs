using BlogAPI.Data;
using BlogAPI.Models.Domain;

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

        public async Task<Blog?> DeleteBlogAsync(int id)
        {
           var existingBlog = dbContext.Blogs.FirstOrDefault(i=>i.BlogId == id);
            if (existingBlog == null)
            {
                return null;
            }
            dbContext.Blogs.Remove(existingBlog);
            await dbContext.SaveChangesAsync();
            return existingBlog;
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return dbContext.Blogs.ToList();
        }

        public async Task<Blog?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Blog?> UpdateBlogAsync(int id, Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
