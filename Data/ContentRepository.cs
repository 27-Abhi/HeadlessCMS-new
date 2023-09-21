using HeadlessCMS.Data;
using HeadlessCMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeadlessCMS.Service
{
    public class ContentRepository : IContentRepository
    {
        private readonly CmsDbContext _context;

        public ContentRepository(CmsDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> UpdateContent(Content content, int id)
        {
            //throw new NotImplementedException();
            // bool isDuplicateTitle = await _context.Page.AnyAsync(a => a.url == content. && a.id != content.Id);

            //if (isDuplicateTitle)
            //{
            //    //throw new InvalidOperationException("A Content with the same URL already exists.");
            //}

            _context.Entry(content).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<bool> DeleteContent(int id)
        {
            var ContentToDelete = await _context.Content.FindAsync(id);
            if (ContentToDelete == null)
                return false;

            _context.Content.Remove(ContentToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Content>> ListContent()
        {
            return await _context.Content.ToListAsync();
        }

        public async Task<IActionResult> CreateContents(Content content)
        {
            await _context.Content.AddAsync(content);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<Content> GetContentById(int id)
        {
            return await _context.Content.FindAsync(id);
            //return true;
        }

        public async Task<List<Content>> GetContentByComp(int id)
        {
            List<Content> contents = await _context.Content
                .Where(c => c.Component_id== id)
                .ToListAsync();

            return contents;
        }

    }
}

    
