using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryWeb.Pages
{
    public class BorrowerModel : PageModel
    {
        [BindProperty]
        public string name { get; set; } = default!;
        [BindProperty]
        public string pw { get; set; } = default!;

        public void OnGet()
        {
        }
    }
}
