using BlogAPI.Models.Domain;

namespace BlogAPI.Repositories
{
    public interface IPostRepository
    {


        Task<Post> CreatePostAsync(Post post);

        Task<List<Post>> GetAllAsync();

        Task<Post?> GetByIdAsync(Guid id);

        Task<Post?> UpdatePostAsync(Guid id, Post post);

        Task<Post?> DeletePostAsync(Guid id);













    }
}
