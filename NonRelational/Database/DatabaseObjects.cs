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
        public string Theme { get; set; }
        public QuestionObject[] Questions { get; set; }
    }
}