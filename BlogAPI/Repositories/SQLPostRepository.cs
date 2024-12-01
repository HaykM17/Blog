using BlogAPI.Data;
using BlogAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repositories
{
    public class SQLPostRepository : IPostRepository
    {


        private readonly BlogDbContext dbContext;

        public SQLPostRepository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        // Create
        public async Task<Post> CreatePostAsync(Post post)
        {
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();
            return post;
        }




        // GetAll
        public async Task<List<Post>> GetAllAsync()
        {
            return await dbContext.Posts.Include(p=>p.Blog).Include(p=>p.Tags).ToListAsync();
        }




        // GetById
        public async Task<Post?> GetByIdAsync(Guid id)
        {
            return await dbContext.Posts.Include(p=>p.Blog).Include(p=>p.Tags).FirstOrDefaultAsync(p => p.PostId == id);
        }




        // Update
        public async Task<Post?> UpdatePostAsync(Guid id, Post post)
        {
            var existingPost = await dbContext.Posts.FirstOrDefaultAsync(p=>p.PostId == id);

            if(existingPost == null)
            {
                return null;
            }

            existingPost.Title = post.Title;
            existingPost.Content = post.Content;

            await dbContext.SaveChangesAsync();
            return existingPost;
        }



        // Delete
        public async Task<Post?> DeletePostAsync(Guid id)
        {
            var existingPost = dbContext.Posts.FirstOrDefault(p=>p.PostId == id);

            if(existingPost == null)
            {
                return null;
            }

            dbContext.Posts.Remove(existingPost);
            await dbContext.SaveChangesAsync();
            return existingPost;
        }

      

       

      
    }
}
