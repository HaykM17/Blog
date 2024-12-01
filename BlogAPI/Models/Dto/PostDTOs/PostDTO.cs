using BlogAPI.Models.Domain;
using BlogAPI.Models.Dto.BlogDTOs;
using BlogAPI.Models.Dto.TagDTOs;

namespace BlogAPI.Models.Dto.PostDTOs
{
    public class PostDTO
    {

        public Guid PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }


        // Foreign Key for Blog
        public Guid BlogId { get; set; }

       
        public ICollection<TagDTO> Tags { get; set; }




    }
}
