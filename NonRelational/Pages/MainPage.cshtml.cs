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
            // Populate the topics, for example from a database or any other source
            NonRelational.Database.Database db = new ("Database/TriviaGame.db");
            Topics = db.GetThemes();
        }
    }
}
