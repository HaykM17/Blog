using BlogAPI.Models.Domain;

namespace BlogAPI.Repositories
{
    public interface IPostRepository
    {



        Task<List<Post>> GetAllAsync();

        Task<Post?> GetByIdAsync(Guid id);

        Task<Post> CreatePostAsync(Post post);

        Task<Post?> UpdateBlogAsync(Guid id, Post post);

        Task<Post?> DeletePostAsync(Guid id);













    }
}
