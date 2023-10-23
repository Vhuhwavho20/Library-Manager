using LibraryWeb.Data;
using LibraryWeb.Models;


namespace LibraryWeb.Services
{
public class LibrarianService
    {
        private readonly LibrarianContext _context = default!;

        public LibrarianService(LibrarianContext context)
        {
            _context = context;
        }

        public IList<Book> GetBooks()
        {
            if(_context.Books != null)
            {
                return _context.Books.ToList();
            }
            return new List<Book>();
        }

        public bool updateBook(int id,int borrower_id){
            if(_context.Books != null){
                var book = _context.Books.FirstOrDefault(e => e.Id == id);
                if (book != null)
                {
                    if(book.status=="Available"){
                    book.status = "NOT Available";
                    book.assigned_borrower = borrower_id;
                    _context.SaveChanges();
                    return true;
                    }
                    return false;
                
                }
                return false;
            }
            return false;

        }

        public void updateBorrower(int id,int ndays){
            if(_context.Borrowers != null){
                var borrower = _context.Borrowers.FirstOrDefault(e => e.Id == id);
                if (borrower != null)
                {
                borrower.penaltiesdue = ndays*30;
                _context.SaveChanges();
                }
            }
        }
        
        public IList<Borrower> GetBorrowers()
        {
            if(_context.Borrowers != null)
            {
                return _context.Borrowers.ToList();
            }
            return new List<Borrower>();
        }

        
        public IList<Librarian> GetLibrarians()
        {
            if(_context.Librarians != null)
            {
                return _context.Librarians.ToList();
            }
            return new List<Librarian>();
        }

        public void AddLibrarian(Librarian librarian)
        {
            if (_context.Librarians != null)
            {
                _context.Librarians.Add(librarian);
                _context.SaveChanges();
            }
        }

        public void DeleteLibrarian(int id)
        {
            if (_context.Librarians != null)
            {
                var librarian = _context.Librarians.Find(id);
                if (librarian != null)
                {
                    _context.Librarians.Remove(librarian);
                    _context.SaveChanges();
                }
            }
        }
    }
}