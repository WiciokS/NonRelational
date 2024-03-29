using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NonRelational.Database;
using System.Globalization;

namespace NonRelational.Pages
{
    public class ScoreBoardModel : PageModel
    {
        public List<ScoreBoardEntryObject> ScoreBoardEntries { get; set; }

        public string SortBy { get; set; }
        public bool SortDescending { get; set; }

        public void OnGet(string sortBy = "TotalScore", bool sortDescending = true)
        {
            SortBy = sortBy;
            SortDescending = sortDescending;
            ScoreBoardEntries = Global.Database.GetScoreBoardList();

            ScoreBoardEntries = SortEntries(ScoreBoardEntries, sortBy, sortDescending);
        }

        private List<ScoreBoardEntryObject> SortEntries(List<ScoreBoardEntryObject> entries, string sortBy, bool descending)
        {
            // Your sorting logic here. For example:
            switch (sortBy)
            {
                case "Username":
                    return descending ? entries.OrderByDescending(e => e.Username).ToList()
                                      : entries.OrderBy(e => e.Username).ToList();
                case "Theme":
                    return descending ? entries.OrderByDescending(e => e.Theme).ToList()
                                      : entries.OrderBy(e => e.Theme).ToList();
                case "AverageScore":
                    return descending ? entries.OrderByDescending(CalculateAverageScore).ToList()
                                      : entries.OrderBy(CalculateAverageScore).ToList();
                case "TotalGamesPlayed":
                    return descending ? entries.OrderByDescending(GetTotalGamesPlayed).ToList()
                                      : entries.OrderBy(GetTotalGamesPlayed).ToList();
                case "TotalScore":
                    return descending ? entries.OrderByDescending(CalculateTotalScore).ToList()
                                      : entries.OrderBy(CalculateTotalScore).ToList();
                case "LastPlayed":
                    return descending ? entries.OrderByDescending(e => e.LastPlayed).ToList()
                                      : entries.OrderBy(e => e.LastPlayed).ToList();
                default:
                    return entries; // No sorting or default sorting
            }
        }

        public double CalculateAverageScore(ScoreBoardEntryObject entry)
        {
            if (entry.Scores == null || !entry.Scores.Any())
            {
                return 0;
            }

            return Double.Round(entry.Scores.Average(), 2);
        }

        public int GetTotalGamesPlayed(ScoreBoardEntryObject entry)
        {
            return entry.Scores.Length;
        }

        public double CalculateTotalScore(ScoreBoardEntryObject entry)
        {
            int totalGames = GetTotalGamesPlayed(entry);
            double averageScore = CalculateAverageScore(entry);

            return averageScore * totalGames;
        }
    }
}
