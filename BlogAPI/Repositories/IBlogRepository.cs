using BlogAPI.Models.Domain;

namespace BlogAPI.Repositories
{
    public interface IBlogRepository
    {

        Task<List<Blog>> GetAllAsync();

        Task<Blog?> GetByIdAsync(int id);

        Task<Blog> CreateBlogAsync(Blog blog);

        Task<Blog?> UpdateBlogAsync(int id,Blog blog);

        Task<Blog?> DeleteBlogAsync(int id);






    }
}
