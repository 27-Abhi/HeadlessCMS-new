using HeadlessCMS.Models;
using Microsoft.AspNetCore.Mvc;

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
        
        public async Task<IActionResult> CreateWebsite(Website website)
        {
            return await _iWebsiteRepository.CreateWebsite(website);
        }

        public async Task<IActionResult> UpdateWebsite(Website website, int id)
        {
            return await _iWebsiteRepository.UpdateWebsite(website, id);
        }

        public async Task<bool> DeleteWebsite(int id)
        {
            return await _iWebsiteRepository.DeleteWebsite(id);
        }

        public async Task<Website> GetWebsiteById(int id)
        {
            return await _iWebsiteRepository.GetWebsiteById(id);
        }
        public async Task<List<Page>> GetPagesByWebsiteId(int id)
        {
            return (List<Page>)await _iWebsiteRepository.GetPagesByWebsiteId(id);
        }
    }
}