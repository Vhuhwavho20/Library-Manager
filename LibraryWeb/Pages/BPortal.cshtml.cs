using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryWeb.Pages
{
    public class BPortalModel : PageModel
    {
        public int ItemId { get; set; }
        public void OnGet(int id)
        {
            ItemId = id;
        }
    }
}
