using HeadlessCMS.Data;
using HeadlessCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HeadlessCMS.Service
{
    public class WebsiteRepository : IWebsiteRepository
    {
        private readonly CmsDbContext _context;

        public WebsiteRepository(CmsDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Website>> ListWebsites()
        {
            return await _context.Website.ToListAsync();
        }
    }
}
