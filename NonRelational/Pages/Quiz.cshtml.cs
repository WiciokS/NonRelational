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
            CurrentQuestion = SelectedTheme?.Questions.ElementAtOrDefault(CurrentQuestionIndex);
        }

        public IActionResult OnPost(string theme)
        {
            SelectedTheme = Global.database.GetTheme(theme);
            CurrentQuestion = SelectedTheme?.Questions.ElementAtOrDefault(CurrentQuestionIndex);
            if (SelectedAnswer == CurrentQuestion?.Answers.FirstOrDefault(a => a.IsCorrect)?.Answer)
            {
                Score++;
                // You can add logic here to keep track of which questions were answered correctly
            }

            CurrentQuestionIndex++;

            if (CurrentQuestionIndex >= SelectedTheme.Questions.Length)
            {
                return RedirectToPage("/Results", new { score = Score, total = SelectedTheme.Questions.Length });
            }

            CurrentQuestion = SelectedTheme?.Questions.ElementAtOrDefault(CurrentQuestionIndex);

            return Page();
        }
    }
}
