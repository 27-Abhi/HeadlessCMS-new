using Microsoft.EntityFrameworkCore;
using HeadlessCMS.Models;

namespace HeadlessCMS.Data
{
    public class CmsDbContext : DbContext
    {

        public CmsDbContext(DbContextOptions<CmsDbContext> options) //setting some options needed by dbcontext like connections string
            : base(options)
        {

        }
        public DbSet<Cms> Cms { get; set; }
    }
}

