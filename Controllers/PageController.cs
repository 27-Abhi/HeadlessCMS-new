using HeadlessCMS.Data;
using HeadlessCMS.Models;
using HeadlessCMS.Service;
using Microsoft.AspNetCore.Mvc;

namespace HeadlessCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController:ControllerBase
    {
        //private readonly CmsDbContext _context;
        //private readonly IWebsiteService _iWebsiteService;
        private readonly IPageService _iPageService;
        //private readonly IComponentsService _iComponentsService;
        //private readonly IContentService _iContentService;

        //public CmsController(CmsDbContext context, IWebsiteService iWebsiteService, IPageService iPageService, IComponentsService iComponentsService, IContentService iContentService)
        //{
        //    //_context = context;
        //    _iWebsiteService = iWebsiteService;
        //    //_iPageService = iPageService;
        //    //_iComponentsService = iComponentsService;
        //    //_iContentService = iContentService;
        //}
        public PageController(IPageService iPageService)
        {
            _iPageService = iPageService;
        }

        [HttpGet]
        public async Task<IEnumerable<Website>> Get()
        {
            var allPages = await _iPageService.ListPages();
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Page page)
        {
            await _iPageService.CreatePage(page);

            return CreatedAtAction(null, new { id = page.id }, page);
            //return Ok(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Page page, int id)
        {
            if (id != page.id)
                return BadRequest();

            await _iPageService.UpdatePage(page, id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            await _iPageService.DeletePage(id);
            return true;
        }
    }
}
