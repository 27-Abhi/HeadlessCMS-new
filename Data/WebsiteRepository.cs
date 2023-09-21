using HeadlessCMS.Data;
using HeadlessCMS.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> CreateWebsite(Website website)
        {
            await _context.Website.AddAsync(website);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<IActionResult> UpdateWebsite(Website website, int id)
        {
            bool isDuplicateTitle = await _context.Website.AnyAsync(a => a.URL == website.URL && a.id != website.id);

            if (isDuplicateTitle)
            {
                throw new InvalidOperationException("A website with the same URL already exists.");
            }

            _context.Entry(website).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<bool> DeleteWebsite(int id)
        {
            var websiteToDelete = await _context.Website.FindAsync(id);
            if (websiteToDelete == null)
                return false;

            _context.Website.Remove(websiteToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Website> GetWebsiteById(int id)
        {
            return await _context.Website.FindAsync(id);
            //return true;
        }
    }

}