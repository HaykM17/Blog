namespace BlogAPI.Models.Domain
{
    public class Post
    {

        public int PostId { get; set; } 

        public string Title { get; set; }

        public string Content { get; set; }


        // Foreign Key for Blog
        public int BlogId { get; set; }

        // Navigation Property for Blog
        public Blog Blog { get; set; }


        public ICollection<Tag> Tags { get; set; }


        public Post()
        {
            Tags = new List<Tag>();
        }


    }
}
