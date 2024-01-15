using Microsoft.AspNetCore.Mvc;
using Milionaires.Database;
using Milionaires.Database.Entities;
using Milionaires.Service;
using System;

namespace Milionaires.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IQuestionService _service;
        public QuestionController(IQuestionService service, MyDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetQuestions()
        {
            var _questions = _service.GetAll();


            if (_questions == null)
            {
                return NotFound(new { message = "Nie masz jeszcze stworzonych pytań!", data = _questions });
            }

            return Ok(_questions);
        }
        [HttpPost("score")]
        public IActionResult SaveScore([FromBody] Score score)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Nieprawidłowe dane");
            }

            _context.Scores.Add(new Score
            {
                Name = score.Name,
                Result = score.Result,
                Date = DateTime.Now
            });

            _context.SaveChanges();
            return Ok("Wynik został zapisany");
        }

    }
}