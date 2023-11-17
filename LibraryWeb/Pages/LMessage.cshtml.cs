using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryWeb.Services;
using LibraryWeb.Models;

namespace LibrayWeb.Pages
{
    public class LMessageModel : PageModel
    {
        private readonly LibrarianService _service;

        public Borrower borrower {get;set;} = default!;

        public IList<Messages> messagelist {get;set;} = default!;

        [BindProperty]
        public string messagetext {get;set;} = default!;

        public LMessageModel(LibrarianService service){
        _service = service;
    }

     public IActionResult OnPost(){
            if (messagetext==null){
                return Page();

            }
            int usr = 0;
            string? param1 = Request.Query["User"];
            if(param1!=null){
                usr = Int32.Parse(param1);
            }

            var chatMessage = new Messages
        {
            msg = messagetext,
            sender="LIBRARIAN",
            borrower_id = usr,
            
        };

            _service.addNewMessage(chatMessage);

            return RedirectToPage("/BMessage");
        }
        public void OnGet()
        {
            IList<Messages> filteredlist = new List<Messages>();
            string? param1 = Request.Query["User"];
            if(param1!=null){
                borrower = _service.getBorrower(Int32.Parse(param1));
                messagelist = _service.GetMessages();
                for(int i = 0;i<messagelist.Count;i++){
                if(messagelist[i].borrower_id==Int32.Parse(param1)){
                    filteredlist.Add(messagelist[i]);
                }
            }
            }

            messagelist = filteredlist;
        }
    }
}
