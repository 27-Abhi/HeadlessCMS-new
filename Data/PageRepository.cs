namespace HeadlessCMS.Service
{
    public class PageRepository:IPageRepository
    {

        public async Task<IActionResult> UpdatePage(Page page, int id)
        {
            //throw new NotImplementedException();
            bool isDuplicateTitle = await _context.Website.AnyAsync(a => a.URL == page.url && a.id != page.id);

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
    }
}
