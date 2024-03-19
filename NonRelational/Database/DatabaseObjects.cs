using LiteDB;

namespace NonRelational.Database
{
    public class AnswerObject
    {
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class QuestionObject
    {
        public string Question { get; set; }
        public AnswerObject[] Answers { get; set; }
    }

    public class ThemeObject
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Theme { get; set; }
        public QuestionObject[] Questions { get; set; }
    }

    public class ScoreBoardEntryObject
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string Theme { get; set; }
        public float[] Scores { get; set; }
        public DateTime LastPlayed { get; set; }

        public ScoreBoardEntryObject()
        {
        }
    }
}