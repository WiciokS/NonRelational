using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NonRelational.Database;

namespace NonRelational.Pages
{
    public class ScoreBoardModel : PageModel
    {
        public List<ScoreBoardEntryObject> ScoreBoardEntries { get; set; }
        public void OnGet()
        {
            ScoreBoardEntries = Global.Database.GetScoreBoardList();
        }

        public double CalculateAverageScore(ScoreBoardEntryObject entry)
        {
            if (entry.Scores == null || !entry.Scores.Any())
            {
                return 0; // Or handle this however you think is appropriate
            }

            return entry.Scores.Average();
        }
    }
}
