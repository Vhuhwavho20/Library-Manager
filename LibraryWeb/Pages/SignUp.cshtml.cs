using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryWeb.Models;
using LibraryWeb.Services;

namespace LibraryWeb.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly LibrarianService _service;

        [BindProperty]
        public string borrower_name {get;set;}=default!;

        [BindProperty]
        public string borrower_num {get;set;}=default!;

        [BindProperty]
        public string borrower_pass {get;set;}=default!;

        [BindProperty]
        public string confirm_pass {get;set;}=default!;

        public SignUpModel(LibrarianService service)
        {
        _service = service;
    }

        public IActionResult OnPost()
{
    if (borrower_name== null || borrower_num==null || borrower_pass==null || confirm_pass==null)
    {
        return Page();
    }

    if(borrower_pass==confirm_pass){
        _service.addNewBorrower(borrower_name,borrower_num,borrower_pass);
        return RedirectToPage();
    }

    


    
    return Page();
}
        public void OnGet()
        {
        }
    }
}
