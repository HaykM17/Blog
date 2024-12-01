using BlogAPI.Data;
using BlogAPI.Models.Domain;

namespace BlogAPI.Repositories
{
    public class SQLPostRepository : IPostRepository
    {


        private readonly BlogDbContext dbContext;

        public SQLPostRepository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<Post> CreatePostAsync(Post post)
        {
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<Post?> DeletePostAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Post?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Post?> UpdateBlogAsync(Guid id, Post post)
        {
            throw new NotImplementedException();
        }
    }
}
