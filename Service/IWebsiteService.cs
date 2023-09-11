using HeadlessCMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeadlessCMS.Service
{
    public interface IWebsiteService
    {
        Task<IEnumerable<Website>> ListWebsites();
        Task<IActionResult> CreateWebsite(Website website);
        Task<IActionResult> UpdateWebsite(Website website, int id);
        Task<bool> DeleteWebsite(int id);
        Task<Website> GetWebsiteById(int id);
    }
}
