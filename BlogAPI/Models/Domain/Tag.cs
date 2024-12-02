namespace BlogAPI.Models.Domain
{
    public class Tag
    {

        public Guid TagId { get; set; }

        public string Name { get; set; }


        public ICollection<Post> Posts { get; set; }


        public Tag()
        {
            Posts = new List<Post>();
        }



        // Soft Delete
        public bool IsDeleted { get; set; }



    }
}
