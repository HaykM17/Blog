using AutoMapper;
using BlogAPI.Models.Domain;
using BlogAPI.Models.Dto.BlogDTOs;
using BlogAPI.Models.Dto.PostDTOs;
using BlogAPI.Models.Dto.TagDTOs;

namespace BlogAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<Blog, BlogDTO>().ReverseMap();
            CreateMap<AddBlogRequestDTO, Blog>().ReverseMap();
            CreateMap<UpdateBlogRequestDTO, Blog>().ReverseMap();

            CreateMap<Post, PostDTO>().ReverseMap();
            CreateMap<AddPostRequestDTO, Post>().ReverseMap();
            CreateMap<UpdatePostRequestDTO, Post>().ReverseMap();

            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<AddTagRequestDTO, Tag>().ReverseMap();
            CreateMap<UpdateTagRequestDTO, Tag>().ReverseMap();
        }








    }
}
