using AutoMapper;
using BlogAPI.Models.Domain;
using BlogAPI.Models.Dto.TagDTOs;
using BlogAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {

        private readonly IBlogRepository blogRepository;
        private readonly ITagRepository tagRepository;
        private readonly IMapper mapper;

        public TagsController(ITagRepository tagRepository, IMapper mapper, IBlogRepository blogRepository)
        {
            this.mapper = mapper;
            this.tagRepository = tagRepository;
            this.blogRepository = blogRepository;
        }







        // POST: /api/Tag
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddTagRequestDTO addTagRequestDTO)
        {
            if(addTagRequestDTO == null)
            {
                return BadRequest("Invalid request data.");
            }

            var tagDomainModel = mapper.Map<Tag>(addTagRequestDTO);

            tagDomainModel = await tagRepository.CreateTagAsync(tagDomainModel);

            var tagDto = mapper.Map<TagDTO>(tagDomainModel);

            return CreatedAtAction(nameof(GetById), new {Id = tagDomainModel.TagId}, tagDto);

        }




        // GET: /api/Tag
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tagDomainModel = await tagRepository.GetAllAsync();
            var tagDto = mapper.Map<List<TagDTO>>(tagDomainModel);
            return Ok(tagDto);
        }








        // GET: /api/Tag/{id}
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var tagDomainModel = await tagRepository.GetByIdAsync(id);

            if(tagDomainModel == null)
            {
                return NotFound();
            }

            var tagDto = mapper.Map<TagDTO>(tagDomainModel);
            return Ok(tagDto);
        }





        // PUT: /api/Tag/{id}
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] UpdateTagRequestDTO updateTagRequestDTO)
        {
            var tagDomainModel = mapper.Map<Tag>(updateTagRequestDTO);
            tagDomainModel = await tagRepository.UpdateTagAsync(id, tagDomainModel);

            if(tagDomainModel == null)
            {
                return NotFound();
            }

            var tagDto = mapper.Map<TagDTO>(tagDomainModel);
            return Ok(tagDto);
        }






        // DELETE: /api/Tag/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var tagDomainModel = await tagRepository.DeleteTagAsync(id);

            if (tagDomainModel == null)
            {
                return NotFound();
            }

            var tagDto = mapper.Map<TagDTO>(tagDomainModel);
            return Ok(tagDto);
        }






















    }
}
