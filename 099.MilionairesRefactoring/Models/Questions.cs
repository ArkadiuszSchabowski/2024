namespace MVC_3September.Models
{
    public class Questions
    {
        public string Question { get; set; }
        public string[] Answers { get; set; }
        public int CorrectAnswerIndex { get; set; }

        public Questions(string question, string[] answers, int index)
        {
            this.Question = question;
            this.Answers = answers;
            this.CorrectAnswerIndex = index;
        }
    }
}
