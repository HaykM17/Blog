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
            var blogDomainModel = mapper.Map<Blog>(addBlogRequestDTO);

            blogDomainModel = await blogRepository.CreateBlogAsync(blogDomainModel);

            var blogDto = mapper.Map<BlogDTO>(blogDomainModel);

            return Ok(blogDto);
        }



        // GET: /api/Blogs

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogsDomainModel = await blogRepository.GetAllAsync();

            var blodsDto = mapper.Map<List<BlogDTO>>(blogsDomainModel);
            return Ok(blodsDto);
        }










    }

}
