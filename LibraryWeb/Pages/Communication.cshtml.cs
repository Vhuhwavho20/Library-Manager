using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryWeb.Models;
using LibraryWeb.Services;

namespace LibraryWeb.Pages
{
    public class CommunicationModel : PageModel
    {
        private readonly LibrarianService _service;

        public IList<Borrower> BorrowerList { get;set; } = default!;

        public CommunicationModel(LibrarianService service){
        _service = service;
    }
        public void OnGet()
        {
            BorrowerList = _service.GetBorrowers();
        }
    }
}
