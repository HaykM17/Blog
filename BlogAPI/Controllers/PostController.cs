using AutoMapper;
using BlogAPI.Models.Domain;
using BlogAPI.Models.Dto.PostDTOs;
using BlogAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IBlogRepository blogRepository;
        private readonly IPostRepository postRepository;
        private readonly IMapper mapper;

        public PostController(IPostRepository postRepository, IMapper mapper, IBlogRepository blogRepository)
        {
            this.mapper = mapper;
            this.postRepository = postRepository;
            this.blogRepository = blogRepository;
        }



        /*
                 [HttpPost]
                 public async Task<IActionResult> Create([FromBody] AddPostRequestDTO addPostRequestDTO)
                 {
                     var postDomainModel = mapper.Map<Post>(addPostRequestDTO);
                     postDomainModel = await postRepository.CreatePostAsync(postDomainModel);
                     var postDto = mapper.Map<PostDTO>(postDomainModel);
                     return Ok(postDto);
                 }
        */





        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPostRequestDTO addPostRequestDTO)
        {
            if (addPostRequestDTO == null)
                return BadRequest("Invalid request data.");

            var blog = await blogRepository.GetByIdAsync(addPostRequestDTO.BlogId);
            if (blog == null)
                return NotFound("Blog not found.");

            var postDomainModel = mapper.Map<Post>(addPostRequestDTO);

            postDomainModel.Blog = blog;

            postDomainModel = await postRepository.CreatePostAsync(postDomainModel);

            var postDto = mapper.Map<PostDTO>(postDomainModel);

            return Ok(postDto);
        }


















    }
}
