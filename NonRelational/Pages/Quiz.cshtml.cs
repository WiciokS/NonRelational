using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NonRelational.Database;
using System.Linq;

namespace NonRelational.Pages
{
    public class QuizModel : PageModel
    {
        public ThemeObject SelectedTheme { get; set; }
        public QuestionObject CurrentQuestion { get; set; }
        public int CurrentQuestionIndex { get; set; } = 0;
        public int Score { get; set; } = 0;

        [BindProperty(SupportsGet = true)]
        public string SelectedAnswer { get; set; }

        public void OnGet(string theme)
        {
            SelectedTheme = Global.database.GetTheme(theme);
            System.Diagnostics.Debug.WriteLine(CurrentQuestionIndex);
        }
    }
}
