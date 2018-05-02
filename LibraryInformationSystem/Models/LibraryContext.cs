using System.Data.Entity;

namespace LibraryInformationSystem.Models
{
    public class LibraryContext : DbContext
    {
        public DbSet<Access> Accesses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public LibraryContext() : base("LibraryInformationSystemConnectionString")
        {

        }
    }
}