using Microsoft.AspNetCore.Mvc;
using Milionaires.Database;
using Milionaires.Database.Entities;
using Milionaires.Service;
using System;

namespace Milionaires.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IGameService _service;
        public GameController(IGameService service, MyDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet("questions")]
        public IActionResult GetQuestions()
        {
            var _questions = _service.GetAllQuestions();

            if (_questions == null)
            {
                return NotFound(new { message = "Nie masz jeszcze stworzonych pytań!", data = _questions });
            }

            return Ok(_questions);
        }
        [HttpGet("scores")]
        public IActionResult GetScores()
        {
            var scores = _service.GetAllScores();
            if(scores == null)
            {
                return NotFound(new { message = "Brak wyników w bazie danych", data = scores });
            }
            return Ok(scores);
        }

        [HttpPost]
        public IActionResult SaveScore([FromBody] Score score)
        {
            Score record = _service.CreateRecord(score);

            if (record == null)
            {
                return BadRequest("Niepoprawne dane");
            }
            return Ok("Wynik został zapisany");
        }
    }
}