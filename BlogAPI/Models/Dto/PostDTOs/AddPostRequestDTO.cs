using BlogAPI.Models.Domain;

namespace BlogAPI.Models.Dto.PostDTOs
{
    public class AddPostRequestDTO
    {

        public string Title { get; set; }

        public string Content { get; set; }


         //Foreign Key for Blog
        public Guid BlogId { get; set; }



       

    }
}
