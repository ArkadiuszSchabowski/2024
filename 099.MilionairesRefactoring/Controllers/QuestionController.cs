using Microsoft.AspNetCore.Mvc;
using Milionaires.Models;
using Milionaires.Service;

namespace Milionaires.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _service;
        public QuestionController(IQuestionService service)
        {
            _service = service;
        }

        public IActionResult GetQuestions()
        {
            var _questions = new List<QuestionAndAnswer> { };

            _questions = _service.GetAll();

            return Json(_questions);
        }
    }
}
