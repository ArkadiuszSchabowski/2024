using Microsoft.AspNetCore.Mvc;
using WordMaster.Database.Entities;
using WordMaster.Services;

namespace WordMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IWordService _service;
        private readonly ILogger<WordController> _logger;

        private const string notFoundMessage = "Nie znaleziono słowa o podanym Id!";
        public WordController(IWordService service, ILogger<WordController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Word>> GetAllWords()
        {
            var allWords = _service.GetAllWords();

            if (allWords == null)
            {
                return NotFound(new { message = "Nie masz jeszcze słów w słowniku!", data = allWords });
            }

            return Ok(new { status = "ok", message = "Słownik wczytany pomyślnie!", data = allWords });
        }

        [HttpGet("{id}")]
        public ActionResult<Word> GetWord(int id)
        {
            var word = _service.GetWord(id);

            if (word == null)
            {
                return NotFound(new { status = "error", action = "getOne", message = notFoundMessage, data = word });
            }
            return Ok(new { message = "Słowo odszukane pomyślnie!", data = word });
        }


        [HttpDelete("{id}")]
        public ActionResult RemoveWord([FromRoute] int id)
        {
            _logger.LogWarning($"RemoveWord {id} has been invoked");

            bool isRemoved = _service.Delete(id);

            if (!isRemoved)
            {
                _logger.LogError($"RemoveWord {id} has been invoked - WRONG ID");
                return NotFound(new { status = "error", message = notFoundMessage });
            }
            return Ok(new { status = "success", action = "remove", message = $"Słowo o Id: {id} zostało usunięte pomyślnie!" });
        }

        [HttpPut("{id}")]
        public ActionResult<object> UpdateWord([FromRoute] int id, [FromBody] Word word)
        {
            _logger.LogWarning($"UpdateWord {id} has been invoked");

            var result = _service.Update(id, word);

            if (result == true)
            {
                return Ok(new { status = "success", action = "update", message = "Słowo zaaktualizowane pomyślnie!" });
            }
            if (result == false)
            {
                _logger.LogError($"UpdateWord {id} has been invoked - WRONG ID");
                return Conflict(new { status = "conflict", conflictType = "duplicate", message = "Przynajmniej jedno ze słów istnieje już w bazie danych!" });
            }
            return NotFound(new { message = notFoundMessage });
        }

        [HttpPost]
        public ActionResult AddNewWord([FromBody] Word word)
        {
            _logger.LogWarning($"AddWord {word} has been invoked");

            bool? isPolishConflict;

            isPolishConflict = _service.Create(word);

            if (isPolishConflict == true)
            {
                _logger.LogError($"AddNewWord has been invoked - polishConflict");
                var polishConflict = new { status = "conflict", conflictType = "conflictPl", message = "Konflikt z polskim odpowiednikiem!" };
                return Conflict(polishConflict);
            }
            if (isPolishConflict == false)
            {
                _logger.LogError($"AddNewWord has been invoked - englishConflict");
                var englishConflict = new { status = "conflict", ConflictType = "conflictEng", message = "Konflikt z angielskim odpowiednikiem!" };
                return Conflict(englishConflict);
            }

            return Ok(new { status = "success", action = "add", message = "Słowo dodane pomyślnie!" });
        }
    }
}