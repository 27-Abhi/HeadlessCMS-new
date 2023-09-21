using HeadlessCMS.Data;
using HeadlessCMS.Models;
using HeadlessCMS.Service;
using Microsoft.AspNetCore.Mvc;

namespace HeadlessCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebsiteController:ControllerBase
    {
        //private readonly CmsDbContext _context;
        private readonly IWebsiteService _iWebsiteService;
        //private readonly IPageService _iPageService;
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
        public WebsiteController(IWebsiteService iWebsiteService)
        {
            _iWebsiteService = iWebsiteService;
        }

        [HttpGet]
        public async Task<IEnumerable<Website>> Get()
        {
            var allWebsites = await _iWebsiteService.ListWebsites();
            return allWebsites;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Website website)
        {
            await _iWebsiteService.CreateWebsite(website);

            return CreatedAtAction(null, new { id = website.id }, website);
            //return Ok(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Website website, int id)
        {
            if (id != website.id)
                return BadRequest();

            await _iWebsiteService.UpdateWebsite(website, id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            //var websiteToDelete = await _context.Website.Delete(id);
            await _iWebsiteService.DeleteWebsite(id);
            return true;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWebsiteById(int id)
        {
            //var issue = await _context.Issues.FindAsync(id);
            var web = await _iWebsiteService.GetWebsiteById(id);

            return web == null ? NotFound() : Ok(web);
        }

        [HttpGet("{id}/pages")]
        public async Task<List<Page>> GetPagesByWebsiteId(int id)
        {
            var pages = await _iWebsiteService.GetPagesByWebsiteId(id);
            return (List<Page>)pages;
        }
    }
}
