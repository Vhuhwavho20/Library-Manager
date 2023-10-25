using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryWeb.Models;
using LibraryWeb.Services;

namespace LibraryWeb.Pages
{
    public class BorrowerModel : PageModel
    {
        private readonly LibrarianService _service;

        public IList<Borrower> BorrowerList { get;set; } = default!;

        [BindProperty]
        public string name { get; set; } = default!;
        [BindProperty]
        public string pw { get; set; } = default!;

        public BorrowerModel(LibrarianService service)
        {
        _service = service;
    }

        public IActionResult OnPost()
{
    if (pw == null || name==null)
    {
        return Page();
    }
    List<Borrower> borrowers = _service.GetBorrowers().ToList();
    for(int i = 0; i < borrowers.Count; i++){
        if(name==borrowers[i].fullname && pw==borrowers[i].password){
            return RedirectToPage("/BPortal");
        }
    }

    
    return Page();
}
        public void OnGet()
        {
        }
    }
}
