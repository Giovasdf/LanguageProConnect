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
    }
}
