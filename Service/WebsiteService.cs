using HeadlessCMS.Models;

namespace HeadlessCMS.Service
{
    public class WebsiteService : IWebsiteService
    {
        private readonly IWebsiteRepository _iWebsiteRepository;//dep injection
        public WebsiteService(IWebsiteRepository iWebsiteRepository)
        {
            _iWebsiteRepository = iWebsiteRepository;
        }
        public async Task<IEnumerable<Website>> ListWebsites()
        {
            return await _iWebsiteRepository.ListWebsites();
        }
    }
}
