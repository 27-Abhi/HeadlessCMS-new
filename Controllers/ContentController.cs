using HeadlessCMS.Data;
using HeadlessCMS.Models;
using HeadlessCMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeadlessCMS.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ContentController : ControllerBase
    {
        //private readonly CmsDbContext _context;
        //private readonly IWebsiteService _iWebsiteService;
        //private readonly IPageService _iPageService;
        //private readonly IComponentsService _iComponentsService;
        private readonly IContentService _iContentService;

        //public CmsController(CmsDbContext context, IWebsiteService iWebsiteService, IPageService iPageService, IComponentsService iComponentsService, IContentService iContentService)
        //{
        //    //_context = context;
        //    _iWebsiteService = iWebsiteService;
        //    //_iPageService = iPageService;
        //    //_iComponentsService = iComponentsService;
        //    //_iContentService = iContentService;
        //}
        public ContentController(IContentService iContentService)
        {
            _iContentService = iContentService;
        }

        [HttpGet]
        public async Task<IEnumerable<Content>> Get()
        {
            var allContent = await _iContentService.ListContent();
            return allContent;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Content content)
        {
            await _iContentService.CreateContents(content);

            return CreatedAtAction(null, new { id = content.id }, content);
            //return Ok(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Content content, int id)
        {
            if (id != content.id)
                return BadRequest();

           var response= await _iContentService.UpdateContent(content, id);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            await _iContentService.DeleteContent(id);
            return true;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetContentById(int id)
        {
            //var issue = await _context.Issues.FindAsync(id);
            var web = await _iContentService.GetContentById(id);

            return web == null ? NotFound() : Ok(web);
        }

        
    }
}
