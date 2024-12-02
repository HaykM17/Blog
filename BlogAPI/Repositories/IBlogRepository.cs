using BlogAPI.Models.Domain;

namespace BlogAPI.Repositories
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllAsync();

        Task<Blog?> GetByIdAsync(Guid id);

        Task<Blog> CreateBlogAsync(Blog blog);


        Task<Blog?> UpdateBlogAsync(Guid id,Blog blog);

        Task<Blog?> DeleteAsync(Guid id);

        Task<Blog?> RestoreBlogAsync(Guid blogId);




    }
}
