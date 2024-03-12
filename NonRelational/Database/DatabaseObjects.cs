namespace NonRelational.Database
{
    public class AnswerObject
    {
        public string Answer { get; set; }
        public Boolean IsCorrect { get; set; }
    }

    public class QuestionObject
    {
        public string Question { get; set; }
        public List<AnswerObject> Answers { get; set; }
    }

    public class ThemeObject
    {
        public string Theme { get; set; }
        public List<QuestionObject> Questions { get; set; }
    }
}