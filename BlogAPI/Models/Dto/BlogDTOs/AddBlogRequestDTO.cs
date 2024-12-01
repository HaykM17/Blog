using BlogAPI.Models.Domain;

namespace BlogAPI.Models.Dto.BlogDTOs
{
    public class AddBlogRequestDTO
    {
        public Guid BlogId { get; set; }
        public string Url { get; set; }

    }
}
