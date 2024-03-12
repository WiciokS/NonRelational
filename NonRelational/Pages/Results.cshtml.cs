using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NonRelational.Pages
{
    public class ResultsModel : PageModel
    {
        public int Score { get; private set; }
        public int TotalQuestions { get; private set; }
        public float Percentage => (float)Score / TotalQuestions * 100;

        public void OnGet(int score, int total)
        {
            Score = score;
            TotalQuestions = total;
        }
    }
}
