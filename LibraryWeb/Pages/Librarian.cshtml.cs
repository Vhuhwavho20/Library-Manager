using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryWeb.Models;
using LibraryWeb.Services;

namespace LibraryWeb.Pages
{
    public class LibrarianModel : PageModel
    {
        private readonly LibrarianService _service;
        public IList<Librarian> LibrarianList { get;set; } = default!;

        public LibrarianModel(LibrarianService service)
        {
        _service = service;
    }

        public void OnGet()
        {
            LibrarianList = _service.GetLibrarians();
        }
    }
}
