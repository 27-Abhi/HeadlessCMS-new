using HeadlessCMS.Data;
using HeadlessCMS.Models;
using HeadlessCMS.Service;
using Microsoft.AspNetCore.Mvc;

namespace HeadlessCMS.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> Update(Content content, int Id)
        {
            if (Id != content.id)
                return BadRequest();

            await _iContentService.UpdateContent(content, Id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int Id)
        {
            await _iContentService.DeleteContent(Id);
            return true;
        }
    }
}
