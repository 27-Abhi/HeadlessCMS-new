using HeadlessCMS.Data;
using HeadlessCMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeadlessCMS.Service
{
    public class PageRepository:IPageRepository
    {
        private readonly CmsDbContext _context;
        public PageRepository(CmsDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> UpdatePage(Page page, int id)
        {
            //throw new NotImplementedException();
            bool isDuplicateTitle = await _context.Page.AnyAsync(a => a.url == page.url && a.id != page.id);

            if (isDuplicateTitle)
            {
                throw new InvalidOperationException("A page with the same URL already exists.");
            }

            _context.Entry(page).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<bool> DeletePage(int id)
        {
            var pageToDelete = await _context.Page.FindAsync(id);
            if (pageToDelete == null)
                return false;

            _context.Page.Remove(pageToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Page>> ListPages()
        {
            return await _context.Page.ToListAsync();
        }

        public async Task<IActionResult> CreatePages(Page page)
        {
            await _context.Page.AddAsync(page);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
