namespace BlogAPI.Models.Domain
{
    public class Blog
    {

        public Guid BlogId { get; set; }

        public string Url { get; set; }

        public ICollection<Post> Posts { get; set; }


        public Blog()
        {
            Posts = new List<Post>();
        }



        // Soft Delete
        public bool IsDeleted { get; set; }









    }
}
