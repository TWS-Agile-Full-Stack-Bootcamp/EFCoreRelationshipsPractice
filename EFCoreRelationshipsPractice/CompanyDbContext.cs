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

        public DbSet<CompanyModel> Companies { get; set; }
    }
}