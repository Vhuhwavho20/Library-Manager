using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryWeb.Models;
using LibraryWeb.Services;

namespace LibraryWeb.Page
{
    public class BorrowedBooksModel : PageModel
    {
    private readonly LibrarianService _service;
    public IList<Book> BookList { get;set; } = default!;

    public BorrowedBooksModel(LibrarianService service){
        _service = service;
    }
        public void OnGet()
        {
            BookList = _service.GetBooks();
        }
    }
}
