using BlogAPI.Models.Domain;

namespace BlogAPI.Repositories
{
    public interface ITagRepository
    {

        Task<List<Tag>> GetAllAsync();

        Task<Tag> GetByIdAsync(Guid id);

        Task<Tag> CreateTagAsync(Tag tag);

        Task<Tag> UpdateTagAsync(Guid id,Tag tag);

        Task<Tag> DeleteTagAsync(Guid id);




















    }
}
