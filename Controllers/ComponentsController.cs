using HeadlessCMS.Data;
using HeadlessCMS.Models;
using HeadlessCMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeadlessCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentsController:ControllerBase
    {
        //private readonly CmsDbContext _context;
        //private readonly IWebsiteService _iWebsiteService;
        //private readonly IPageService _iPageService;
        private readonly IComponentsService _iComponentsService;
        //private readonly IContentService _iContentService;

        //public CmsController(CmsDbContext context, IWebsiteService iWebsiteService, IPageService iPageService, IComponentsService iComponentsService, IContentService iContentService)
        //{
        //    //_context = context;
        //    _iWebsiteService = iWebsiteService;
        //    //_iPageService = iPageService;
        //    //_iComponentsService = iComponentsService;
        //    //_iContentService = iContentService;
        //}
        public ComponentsController(IComponentsService iComponentsService)
        {
            _iComponentsService = iComponentsService;
        }

        [HttpGet]
        public async Task<IEnumerable<Components>> Get()
        {
            var allComponents = await _iComponentsService.ListComponents();
            return allComponents;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Components components)
        {
            await _iComponentsService.CreateComponents(components);

            return CreatedAtAction(null, new { id = components.id }, components);
            //return Ok(201);
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Components components, int id)
        {
            if (id != components.id)
                return BadRequest();

            await _iComponentsService.UpdateComponents(components, id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            await _iComponentsService.DeleteComponents(id);
            return true;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComponentsById(int id)
        {
            var components = await _iComponentsService.GetComponentsById(id);
            return components == null ? NotFound() : Ok(components);
        }

        [HttpGet("{id}/content")]
        public async Task<List<Content>> GetContentByComponentId(int id)
        {
            var content = await _iComponentsService.GetContentByComponentId(id);
            return content;
        }
    }
}
