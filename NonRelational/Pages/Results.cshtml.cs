using Microsoft.AspNetCore.Mvc.RazorPages;
using NonRelational.Database;

namespace NonRelational.Pages
{
    public class ResultsModel : PageModel
    {
        public int Score { get; private set; }
        public int TotalQuestions { get; private set; }
        public float Percentage => (float)Score / TotalQuestions * 100;
        public string Theme { get; private set; }
        public bool Published = false;

        public void OnGet(int score, int total, string theme)
        {
            Score = score;
            TotalQuestions = total;
            Theme = theme;
        }

        public void OnPost(string username, string theme, float percentage)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(theme))
            {
                return;
            }

            List<ScoreBoardEntryObject> collection = Global.Database.GetScoreBoardList();

            var entry = new ScoreBoardEntryObject
            {
                Username = username,
                Theme = theme,
                LastPlayed = DateTime.Now // Set the LastPlayed time here for new and existing entries
            };

            var existingEntry = collection.FirstOrDefault(x => x.Username == username && x.Theme == theme);
            if (existingEntry != null)
            {
                existingEntry.Scores = existingEntry.Scores.Concat(new[] { percentage }).ToArray();
                existingEntry.LastPlayed = entry.LastPlayed;
                Global.Database.UpdateScoreBoardEntry(existingEntry);
            }
            else
            {
                entry.Scores = new[] { percentage };
                Global.Database.InsertScoreBoardEntry(entry);
            }

            Published = true;
        }

    }
}
