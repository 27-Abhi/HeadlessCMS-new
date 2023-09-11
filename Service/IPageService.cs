using HeadlessCMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeadlessCMS.Service
{
    public interface IPageService
    { 
        Task<IEnumerable<Page>> ListPages();
        Task<IActionResult> CreatePage(Page page);
        Task<IActionResult> UpdatePage(Page page, int id);
        Task<bool> DeletePage(int id);
    }
}
