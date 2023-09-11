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
        //    _iContentService = iContentService;
        //}
        public ContentController(IContentService iContentService)
        {
            _iContentService = iContentService;
        }

        [HttpGet]
        public async Task<IEnumerable<Content>> Get()
        {
            var allContent = await _iContentService.ListContent();
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Content content)
        {
            await _iContentService.CreateContent();

            return CreatedAtAction(null, new { id = content.Id }, content);
            //return Ok(201);
        }

    }
}
