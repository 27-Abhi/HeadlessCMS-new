using HeadlessCMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeadlessCMS.Service
{
    public interface IWebsiteService
    {
        Task<IEnumerable<Website>> ListWebsites();
        Task<IActionResult> CreateWebsite(Website website);
    }
}
