using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryWeb.Models;
using LibraryWeb.Services;



namespace LibrayWeb.Pages
{
    public class DeallocationModel : PageModel
    {
        private readonly LibrarianService _service;

        public DeallocationModel(LibrarianService service){
        _service = service;
    }

        public void OnGet()
        {
            string? param1 = Request.Query["BookID"];
            if(param1!=null){
                int book_id = Int32.Parse(param1);
                bool outcome =_service.book_deallocated(book_id);
            }

            


        }
    }
}
