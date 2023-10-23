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

        
        [BindProperty]
        public string searchquery{get; set;} = default!;

        public CommunicationModel(LibrarianService service){
        _service = service;
    }

    public IActionResult OnPost(){
        if(searchquery==null){
            return Page();
        }
        List<Borrower> borrowers = _service.GetBorrowers().ToList();
    List<Borrower> searchresult = new List<Borrower>();
    for(int i = 0; i< borrowers.Count;i++){
        string? borrower_in_library = borrowers[i].fullname;
        if(borrower_in_library?.ToLower().IndexOf(searchquery.ToLower())!=-1){
            searchresult.Add(borrowers[i]);
        }
    }
    
    BorrowerList = searchresult;





        return Page();
    }

    public IActionResult Redirect_Click()
{
    return RedirectToPage("/Message");
}

        public void OnGet()
        {
            BorrowerList = _service.GetBorrowers();
        }
    }
}
