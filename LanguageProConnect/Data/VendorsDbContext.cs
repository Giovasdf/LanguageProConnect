using LanguageProConnect.Models;
using Microsoft.EntityFrameworkCore;

namespace LanguageProConnect.Data
{
    public class VendorsDbContext : DbContext
    {
        public VendorsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<LanguageSpoken> LanguageSpokens { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<LanguageSpoken>().HasData(
                new LanguageSpoken { Id = Guid.NewGuid(), Name = "English" },
                new LanguageSpoken { Id = Guid.NewGuid(), Name = "Spanish" },
                new LanguageSpoken { Id = Guid.NewGuid(), Name = "Portuguese" }
            );

            modelBuilder.Entity<School>().HasData(
                new School { Id = Guid.NewGuid(), Name = "Ned", Country = "Ireland", City = "Limerick" },
                new School { Id = Guid.NewGuid(), Name = "Student Campus", Country = "Ireland", City = "Limerick" },
                new School { Id = Guid.NewGuid(), Name = "ELI", Country = "Ireland", City = "Limerick" }

            );
        }
    }
}
