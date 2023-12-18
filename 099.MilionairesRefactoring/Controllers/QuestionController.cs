using Microsoft.AspNetCore.Mvc;
using Milionaires.Models;
using Milionaires.Service;

namespace Milionaires.Controllers
{
    public class QuestionController : Controller
    {
        public QuestionController()
        {
        }

        public IActionResult GetQuestions()
        {
            var _questions = new List<QuestionAndAnswer> { };

            QuestionService service = new QuestionService();
            _questions = service.AllQuestions();

            return Json(_questions);
        }
    }
}
