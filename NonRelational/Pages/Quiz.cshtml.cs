using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NonRelational.Database;
using System.Linq;

namespace NonRelational.Pages
{
    public class QuizModel : PageModel
    {
        public ThemeObject SelectedTheme { get; set; }

        public void OnGet(string theme)
        {
            SelectedTheme = Global.Database.GetTheme(theme);
        }
    }
}
