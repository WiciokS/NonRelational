using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using NonRelational.Database;

namespace NonRelational.Pages
{
    public class MainPageModel : PageModel
    {
        public List<ThemeObject> Topics { get; set; }

        public void OnGet()
        {
            Topics = Global.Database.GetThemes();
        }
    }
}
