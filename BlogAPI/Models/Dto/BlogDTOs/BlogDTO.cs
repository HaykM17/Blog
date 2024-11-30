﻿using BlogAPI.Models.Domain;

namespace BlogAPI.Models.Dto.BlogDTOs
{
    public class BlogDTO
    {
        public int BlogId { get; set; }

        public string Url { get; set; }

        public ICollection<Post?> Posts { get; set; }


    }
}