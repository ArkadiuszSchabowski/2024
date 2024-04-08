using Microsoft.AspNetCore.Mvc;
using WordMaster.Server.Models;
using WordMaster.Server.Services;
using WordMaster.ServerDatabase.Entities;

namespace WordMaster.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashCardController : ControllerBase
    {
        private readonly IFlashCardService _service;

        public FlashCardController(IFlashCardService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<FlashCard>> GetFlashCards()
        {
            var flashcards = _service.GetFlashCards();
            return Ok(flashcards);
        }
        [HttpGet("polish")]
        public ActionResult<FlashCard> GetPolishFlashCard([FromQuery] string word) 
        {
            FlashCard flashcard = _service.GetPolishFlashCard(word);
            return Ok(flashcard);
        }
        [HttpGet("english")]
        public ActionResult<FlashCard> GetEnglishFlashCard([FromQuery] string word)
        {
            FlashCard flashcard = _service.GetEnglishFlashCard(word);
            return Ok(flashcard);
        }
        [HttpPost]
        public ActionResult AddWord([FromBody] FlashCardDto dto)
        {
            _service.AddWord(dto);
            return Ok("Słowo dodane pomyślnie");
        }
    }
}
