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
        public PageController(IWebsiteService iWebsiteService)
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
    }
}
