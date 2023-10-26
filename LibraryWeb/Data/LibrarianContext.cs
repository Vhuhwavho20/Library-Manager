using Microsoft.EntityFrameworkCore;

namespace LibraryWeb.Data{

    //Database context
    public class LibrarianContext : DbContext
    {
        public LibrarianContext(DbContextOptions<LibrarianContext> options)
            : base(options)
        {
        }

        //Adding various tables to the database
        public DbSet<LibraryWeb.Models.Librarian>? Librarians { get; set; }
        public DbSet<LibraryWeb.Models.Book>? Books{get;set;}

        public DbSet<LibraryWeb.Models.Borrower>? Borrowers{get;set;}

        public DbSet<LibraryWeb.Models.Messages>? messages{get;set;}
    }
}
