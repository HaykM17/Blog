using AutoMapper;
using BlogAPI.Models.Domain;
using BlogAPI.Models.Dto.BlogDTOs;

namespace BlogAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<Blog, BlogDTO>().ReverseMap();

            CreateMap<AddBlogRequestDTO, Blog>().ReverseMap();
            CreateMap<UpdateBlogRequestDTO, Blog>().ReverseMap();

        }








    }
}
