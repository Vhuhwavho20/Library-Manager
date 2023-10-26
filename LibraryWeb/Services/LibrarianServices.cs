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

        //Retrieve list of books from database
        public IList<Book> GetBooks()
        {
            if(_context.Books != null)
            {
                return _context.Books.ToList();
            }
            return new List<Book>();
        }

        //Update status of book in database and return boolean to indicate whether update was successful
        public bool updateBook(int id,int borrower_id){
            if(_context.Books != null){
                var book = _context.Books.FirstOrDefault(e => e.Id == id);
                if (book != null)
                {
                    //check if book is available
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

        //Retrieve a Borrower using their primary key
        public Borrower getBorrower(int id){
            if(_context.Borrowers!=null){
                Borrower? b1 = _context.Borrowers.Find(id);
                return b1;
            }
            return new Borrower();
        }

        //Add a new Borrower to Borrower table in the database
        public void addNewBorrower(Borrower newBorrower){ 
            if(_context.Borrowers!=null){
                _context.Borrowers.Add(newBorrower);
                _context.SaveChanges();
            }
            
        }

        //update the penalties charged to the borrower
        public void updateBorrower(int id,int ndays){
            if(_context.Borrowers != null){
                var borrower = _context.Borrowers.FirstOrDefault(e => e.Id == id);
                if (borrower != null)
                {
                borrower.penaltiesdue = borrower.penaltiesdue+ (ndays*30);
                _context.SaveChanges();
                }
            }
        }
        
        //Retrieve list of borrowers from Database
        public IList<Borrower> GetBorrowers()
        {
            if(_context.Borrowers != null)
            {
                return _context.Borrowers.ToList();
            }
            return new List<Borrower>();
        }

        //Retrieve list of librarians from database
        public IList<Librarian> GetLibrarians()
        {
            if(_context.Librarians != null)
            {
                return _context.Librarians.ToList();
            }
            return new List<Librarian>();
        }
        
        //Add new Librarian to Librarian Table in the database
        public void AddLibrarian(Librarian librarian)
        {
            if (_context.Librarians != null)
            {
                _context.Librarians.Add(librarian);
                _context.SaveChanges();
            }
        }

        //Remove librarian from the database
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