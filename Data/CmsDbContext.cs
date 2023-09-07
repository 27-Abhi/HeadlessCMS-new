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
        public DbSet<website> website { get; set; }
        public DbSet<Content> content  { get; set; }
        public DbSet<page> page { get; set; }
        public DbSet<components> components { get; set; }

    }
}

