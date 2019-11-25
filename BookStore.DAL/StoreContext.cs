using EntitiesLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=bookstore;Trusted_Connection=True;");
        }

        public DbSet<PrintingEdition> PrintingEditions { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBooks> AuthorBooks { get; set; }
    }
}
