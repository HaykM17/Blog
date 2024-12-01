using AutoMapper;
using BlogAPI.Models.Domain;
using BlogAPI.Models.Dto.BlogDTOs;
using BlogAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository blogRepository;
        private readonly IMapper mapper;

        public BlogsController(IBlogRepository blogRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.blogRepository = blogRepository;
        }






        // POST: /api/Blogs

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddBlogRequestDTO addBlogRequestDTO)
        {
            if(addBlogRequestDTO == null)
            {
                return BadRequest("Invalid request data.");
            }

            var blogDomainModel = mapper.Map<Blog>(addBlogRequestDTO);

             blogDomainModel = await blogRepository.CreateBlogAsync(blogDomainModel);

            var blogDto = mapper.Map<BlogDTO>(blogDomainModel);

            return CreatedAtAction(nameof(GetById),new {Id = blogDomainModel.BlogId}, blogDto);
        }












        // GET: /api/Blogs

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogsDomainModel = await blogRepository.GetAllAsync();

            var blogsDto = mapper.Map<List<BlogDTO>>(blogsDomainModel);
            return Ok(blogsDto);
        }





        // Get: /api/Blogs/{id}

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var blogDomainModel = await blogRepository.GetByIdAsync(id);

            if(blogDomainModel == null)
            {
                return NotFound();
            }

            var blogDto = mapper.Map<BlogDTO>(blogDomainModel);
            return Ok(blogDto);
        }






        // Put: /api/Blogs/{id}

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] UpdateBlogRequestDTO updateBlogRequestDTO)
        {
            var blogDomainModel = mapper.Map<Blog>(updateBlogRequestDTO);

            blogDomainModel = await blogRepository.UpdateBlogAsync(id, blogDomainModel);

            if(blogDomainModel == null)
            {
                return NotFound();
            }

            var blogDto = mapper.Map<BlogDTO> (blogDomainModel);
            return Ok(blogDto);
        }




        // Delete: /api/Blogs/{id}
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var deletedBlogDomainModel = await blogRepository.DeleteAsync(id);

            if(deletedBlogDomainModel == null)
            {
                return NotFound();
            }

            var blogDto = mapper.Map<BlogDTO>(deletedBlogDomainModel);
            return Ok(blogDto);
        }















    }

}
