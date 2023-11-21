using Microsoft.EntityFrameworkCore;

namespace Lab12.Models
{
    public class ApplicationUserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationUserContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=UsersDB;Trusted_Connection=True;");
        }
    }
}
