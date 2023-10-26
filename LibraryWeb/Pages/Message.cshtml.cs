using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryWeb.Models;
using LibraryWeb.Services;
using Microsoft.AspNetCore.SignalR;

namespace LibraryWeb.Pages
{
    public class MessageModel : PageModel
    {
        private readonly LibrarianService _service;

        public Borrower borrower {get;set;} = default!;

        [BindProperty]
        public string messagetext {get;set;} = default!;

        public MessageModel(LibrarianService service){
        _service = service;
    }


        public IActionResult OnPost(){
            if (messagetext==null){
                return Page();

            }

            return Page();
        }
        public void OnGet()
        {
            string? param1 = Request.Query["User"];
            if(param1!=null){
                borrower = _service.getBorrower(Int32.Parse(param1));
            }
            
            

        }
    }
}
