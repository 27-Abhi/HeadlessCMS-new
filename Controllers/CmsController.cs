using HeadlessCMS.Data;
using HeadlessCMS.Models;
using HeadlessCMS.Service;
using Microsoft.AspNetCore.Mvc;

namespace HeadlessCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CmsController:ControllerBase
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
        public CmsController(IWebsiteService iWebsiteService)
        {
            _iWebsiteService = iWebsiteService;
        }

        [HttpGet]
        public async Task<IEnumerable<Website>> Get()
        {
            var allWebsites = await _iWebsiteService.ListWebsites();
            return allWebsites;
        }
    }
}
