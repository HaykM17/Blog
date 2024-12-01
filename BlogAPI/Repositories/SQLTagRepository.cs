using BlogAPI.Data;
using BlogAPI.Models.Domain;

namespace BlogAPI.Repositories
{
    public class SQLTagRepository : ITagRepository
    {
        private readonly BlogDbContext dbContext;

        public SQLTagRepository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }









        public async Task<Tag> CreateTagAsync(Tag tag)
        {
            throw new NotImplementedException();
        }

        public async Task<Tag> DeleteTagAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Tag>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Tag> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Tag> UpdateTagAsync(Guid id, Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
