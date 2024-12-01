using BlogAPI.Models.Domain;

namespace BlogAPI.Models.Dto.PostDTOs
{
    public class PostDTO
    {

        public Guid PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }


        // Foreign Key for Blog
        public Guid BlogId { get; set; }

        // Navigation Property for Blog
        //public Blog Blog { get; set; }


        public ICollection<Tag> Tags { get; set; }




    }
}
