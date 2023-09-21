using HeadlessCMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeadlessCMS.Service
{
    public interface IPageService
    {
        Task<IEnumerable<Page>> ListPages();
        Task<IActionResult> CreatePage(Page page);
        Task<bool> UpdatePage(Page page, int id);
        Task<bool> DeletePage(int id);
        Task<List<Components>> GetComponentsByPage(int id);
    }
}
