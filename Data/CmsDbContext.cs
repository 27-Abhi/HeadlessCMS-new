using Microsoft.EntityFrameworkCore;
using HeadlessCMS.Models;
using static HeadlessCMS.Models.Content;

namespace HeadlessCMS.Data
{
    public class CmsDbContext : DbContext
    {

        public CmsDbContext(DbContextOptions<CmsDbContext> options) //setting some options needed by dbcontext like connections string
            : base(options)
        {

        }
        public DbSet<Website> Website { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<Components> Components { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define primary keys for entities (if needed)
            modelBuilder.Entity<Website>().HasKey(w => w.id);
            modelBuilder.Entity<Content>().HasKey(c => c.id);
            modelBuilder.Entity<Page>().HasKey(p => p.id);

            modelBuilder.Entity<Content>()
                .OwnsOne(c => c.mediaJSON);



        }
    }
}
