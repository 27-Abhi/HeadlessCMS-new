using HeadlessCMS.Data;
using HeadlessCMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeadlessCMS.Service
{
    public class ComponentsRepository : IComponentsRepository
    {
        private readonly CmsDbContext _context;

        public ComponentsRepository(CmsDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CreateComponents(Components components)
        {
            await _context.Components.AddAsync(components);
            await _context.SaveChangesAsync();
            return null;
        }


        public async Task<IEnumerable<Components>> ListComponents()
        {
            return await _context.Components.ToListAsync();
        }

        public async Task<IActionResult> UpdateComponents(Components components, int id)
        {
            bool isDuplicateTitle = await _context.Components.AnyAsync(a => a.id != components.id);

            if (isDuplicateTitle)
            {
                throw new InvalidOperationException("A component with the same id already exists.");
            }

            _context.Entry(components).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<bool> DeleteComponents(int id)
        {
            var componentToDelete = await _context.Components.FindAsync(id);
            if (componentToDelete == null)
                return false;

            _context.Components.Remove(componentToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Components> GetComponentsById(int id)
        {
            var component = await _context.Components.FindAsync(id);
            return component;
        }

        public async Task<List<Content>> GetContentByComponentId(int id)
        {
            List<Content> content = await _context.Content
                           .Where(c => c.Component_id == id)
                           .ToListAsync();

            return content;
        }
    }
}
