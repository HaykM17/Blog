using BlogAPI.Data;
using BlogAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace BlogAPI.Repositories
{
    public class SQLTagRepository : ITagRepository
    {
        private readonly BlogDbContext dbContext;

        public SQLTagRepository(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }









        // Create
        public async Task<Tag> CreateTagAsync(Tag tag)
        {
            await dbContext.AddAsync(tag);
            await dbContext.SaveChangesAsync();
            return tag;
        }






        // GetAll
        public async Task<List<Tag>> GetAllAsync()
        {
            return await dbContext.Tags.Include(t=>t.Posts).ThenInclude(p=>p.Blog).ToListAsync();
        }




        // GetById
        public async Task<Tag?> GetByIdAsync(Guid id)
        {
            return await dbContext.Tags.Include(t => t.Posts).ThenInclude(p => p.Blog).FirstOrDefaultAsync(t=>t.TagId==id);
        }





        // Update
        public async Task<Tag> UpdateTagAsync(Guid id, Tag tag)
        {
            var existingTag = await dbContext.Tags.FirstOrDefaultAsync(t=>t.TagId==id);
            if(existingTag == null)
            {
                return null;
            }

            existingTag.Name = tag.Name;
            await dbContext.SaveChangesAsync();
            return existingTag;
        }




        public async Task<Tag> DeleteTagAsync(Guid id)
        {
            var existingTag = dbContext.Tags.FirstOrDefault(t=>t.TagId==id);

            if (existingTag == null)
            {
                return null;
            }

            dbContext.Tags.Remove(existingTag);
            await dbContext.SaveChangesAsync();
            return existingTag;
        }



        // For Restore Tag Soft Deleted Records
        public async Task<Tag?> RestoreTagAsync(Guid tagId)
        {
            var tag = await dbContext.Tags.IgnoreQueryFilters().FirstOrDefaultAsync(t => t.TagId == tagId);

            if (tag == null)
            {
                return null;
            }

            tag.IsDeleted = false;
            await dbContext.SaveChangesAsync();

            return tag;
        }
    }
}
