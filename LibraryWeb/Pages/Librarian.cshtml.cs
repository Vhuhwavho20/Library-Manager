using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryWeb.Models;
using LibraryWeb.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LibraryWeb.Pages
{
    public class LibrarianModel : PageModel
    {
        private readonly LibrarianService _service;
        public IList<Librarian> LibrarianList { get;set; } = default!;
        [BindProperty]
        public string name { get; set; } = default!;
        [BindProperty]
        public string pw { get; set; } = default!;

        public LibrarianModel(LibrarianService service)
        {
        _service = service;
    }
    
    public IActionResult OnPost()
{
    if (pw == null || name==null)
    {
        return Page();
    }
    List<Librarian> librarians = _service.GetLibrarians().ToList();
    for(int i = 0; i < librarians.Count; i++){
        if(name==librarians[i].fullname){
            Console.WriteLine("Log In successful");
        }
    }

    
    return Redirect("https://example.com");
}

        public void OnGet()
        {
            LibrarianList = _service.GetLibrarians();
        }
    }
}
