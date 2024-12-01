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



       // POST: /api/Post

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

            return CreatedAtAction(nameof(GetById), new {Id = postDomainModel.PostId}, postDto);
        }






        // GET: /api/Post

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var postDomainModel = await postRepository.GetAllAsync();
            var postDTO = mapper.Map<List<PostDTO>>(postDomainModel);
            return Ok(postDTO);
        }






        // GetById: /api/Post/{id}
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var postDomainModel = await postRepository.GetByIdAsync(id);

            if(postDomainModel == null)
            {
                return NotFound();
            }

            var postDto = mapper.Map<PostDTO>(postDomainModel);
            return Ok(postDto);
        }






        // PUT: /api/Post/{id}
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody]UpdatePostRequestDTO updatePostRequestDTO)
        {
            var postDomainModel = mapper.Map<Post>(updatePostRequestDTO);

            postDomainModel = await postRepository.UpdatePostAsync(id, postDomainModel);

            if(postDomainModel == null)
            {
                return NotFound();
            }

            var postDto = mapper.Map<PostDTO>(postDomainModel);
            return Ok(postDto);
        }






        // DELETE: /api/Post/{id}
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var postDomainModel = await postRepository.DeletePostAsync(id);

            if (postDomainModel == null)
            {
                return NotFound();
            }

            var postDto = mapper.Map<PostDTO>(postDomainModel);
            return Ok(postDto);
        }




















    }
}
