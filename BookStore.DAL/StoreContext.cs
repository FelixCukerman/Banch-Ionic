using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=bookstore;Trusted_Connection=True;");
        }
    }
}
