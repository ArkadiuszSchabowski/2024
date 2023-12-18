using Microsoft.AspNetCore.Mvc;
using Milionaires.Models;

namespace Milionaires.Controllers
{
    public class QuestionController : Controller
    {
        public QuestionController()
        {
            SetQuestions();
        }
        private List<QuestionAndAnswer> _questions = new List<QuestionAndAnswer> { };
        public void SetQuestions()
        {
            QuestionsData questionsData = new QuestionsData();
            _questions = questionsData.AllQuestions();
        }
        public IActionResult GetQuestions()
        {
            return Json(_questions);
        }
    }
}
