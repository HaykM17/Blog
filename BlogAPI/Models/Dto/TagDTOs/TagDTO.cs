using BlogAPI.Models.Domain;

namespace BlogAPI.Models.Dto.TagDTOs
{
    public class TagDTO
    {

        public Guid TagId { get; set; }

        public string Name { get; set; }


        //public ICollection<Post> Posts { get; set; }


    }
}
