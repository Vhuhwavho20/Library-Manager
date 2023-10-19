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

    [BindProperty]
    public string searchquery{get; set;} = default!;

    [BindProperty]
    public string num_days {get; set;} = default!;

    [BindProperty]
    public string borrower_id {get;set;} = default!;

    [BindProperty]
    public string book_id {get;set;} = default!;

    public InventoryModel(LibrarianService service){
        _service = service;
    }

    public IActionResult OnPost()
{
    if (searchquery==null)
    {
        return Page();
    }
    List<Book> books = _service.GetBooks().ToList();
    List<Book> searchresult = new List<Book>();
    for(int i = 0; i< books.Count;i++){
        string? book_in_library = books[i].book_title;
        if(book_in_library?.ToLower().IndexOf(searchquery.ToLower())!=-1){
            searchresult.Add(books[i]);
        }
    }
    BookList = searchresult;


    
    return Page();
}
        public void OnGet()
        {
            BookList = _service.GetBooks();
        }
    }
}
