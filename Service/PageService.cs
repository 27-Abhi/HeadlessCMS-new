using HeadlessCMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeadlessCMS.Service
{
    public class PageService:IPageService
    {
        private readonly IPageRepository _iPageRepository;//dep injection
        public PageService(IPageRepository iPageRepository)
        {
            _iPageRepository = iPageRepository;
        }

        public async Task<IActionResult> CreatePage(Models.Page page)
        {
            return await _iPageRepository.CreatePages(page);
        }

        public async Task<IEnumerable<Models.Page>> ListPages()
        {
            return await _iPageRepository.ListPages();
        }

        public async Task<bool> UpdatePage(Models.Page page, int id)
        {
            try
            {
                await _iPageRepository.UpdatePage(page, id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeletePage(int id)
        {
            return await _iPageRepository.DeletePage( id);
        }

        public async Task<List<Components>> GetComponentsByPage(int id)
        {
            return await _iPageRepository.GetComponentsByPage(id);
        }
    }
}