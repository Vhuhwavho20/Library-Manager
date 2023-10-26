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

    public Borrower user {get;set;}=default!;


    public BorrowedBooksModel(LibrarianService service){
        _service = service;
    }
        public void OnGet()
        {
            BookList = _service.GetBooks();
            IList<Book> filteredlist = new List<Book>();
            string? param1 = Request.Query["User"];
            if(param1!=null){
                user = _service.getBorrower(Int32.Parse(param1));
            }
            
            for(int i = 0; i <BookList.Count;i++){
                if(param1!=null){
                    if(BookList[i].assigned_borrower==Int32.Parse(param1)){
                        filteredlist.Add(BookList[i]);
                }
                }
                
            }

            BookList = filteredlist;
        }
    }
}
