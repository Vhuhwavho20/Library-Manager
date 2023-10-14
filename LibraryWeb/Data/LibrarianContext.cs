using Microsoft.EntityFrameworkCore;

namespace LibraryWeb.Data{

    public class LibrarianContext : DbContext
    {
        public LibrarianContext(DbContextOptions<LibrarianContext> options)
            : base(options)
        {
        }
        public DbSet<LibraryWeb.Models.Librarian>? Librarians { get; set; }
    }
}
