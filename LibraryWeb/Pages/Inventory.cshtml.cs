using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryWeb.Models;
using LibraryWeb.Services;

namespace LibraryWeb.Pages
{
    public class InventoryModel : PageModel
    {
    private readonly LibrarianService _service;
    public IList<Book> BookList { get;set; } = default!;

    public InventoryModel(LibrarianService service){
        _service = service;
    }
        public void OnGet()
        {
            BookList = _service.GetBooks();
        }
    }
}
