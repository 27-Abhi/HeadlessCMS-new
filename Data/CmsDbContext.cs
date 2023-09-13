using Microsoft.EntityFrameworkCore;
using HeadlessCMS.Models;
using Newtonsoft.Json;
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
            modelBuilder.Entity<Content>(e =>
            {

                e.Property(p => p.MediaJSON)
                    .HasColumnType("json")
                    .HasConversion(
                        v => JsonConvert.SerializeObject(v),
                        v => JsonConvert.DeserializeObject<Media>(v)
                    );
            });
        }
    }
}
