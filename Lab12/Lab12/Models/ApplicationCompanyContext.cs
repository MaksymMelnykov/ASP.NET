using Microsoft.EntityFrameworkCore;

namespace Lab12.Models
{
    public class ApplicationCompanyContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public ApplicationCompanyContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CompaniesDB;Trusted_Connection=True;");
        }
    }
}
