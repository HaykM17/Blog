using BlogAPI.Models.Domain;
using BlogAPI.Models.Dto.PostDTOs;
using BlogAPI.Models.Dto.TagDTOs;

namespace BlogAPI.Models.Dto.BlogDTOs
{
    public class BlogDTO
    {
        public Guid BlogId { get; set; }

        public string Url { get; set; }

        public ICollection<PostDTO> Posts { get; set; }
        public ICollection<TagDTO> Tags { get; set; }


    }
}
