using EFCoreRelationshipsPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreRelationshipsPractice
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Profile> Profiles { get; set; }
    }
}