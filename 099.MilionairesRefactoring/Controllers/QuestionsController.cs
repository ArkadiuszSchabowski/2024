using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MVC_3September.Models;
using System.Collections;
using System.Security.Cryptography.Xml;
using MVC_3September.Models.MVC_3September.Models;

namespace MVC_3September.Controllers
{
    public class QuestionsController : Controller
    {
        public QuestionsController()
        {
            SetQuestions();
        }
        private List<Questions> _questions = new List<Questions> { };

        public void SetQuestions()
        {
            QuestionsData questionsData = new QuestionsData();
            _questions = questionsData.AllQuestions();
        }
        public IActionResult Index()
        {
            return View(_questions);
        }

        public IActionResult GetQuestions()
        {
            return Json(_questions);
        }
    }
}
