using HeadlessCMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeadlessCMS.Service
{
    public interface IPageRepository
    {

        public Task<IEnumerable<Page>> ListPages();
      //  public Task<Task> CreatePages(Page page);
        public Task<IActionResult> CreatePages(Page page);
        Task<IActionResult> UpdatePage(Page page, int id);
        Task<bool> DeletePage(int id);
    }
}
