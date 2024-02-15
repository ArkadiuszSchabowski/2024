using _086.ThrowTraining.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace _086.ThrowTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        public readonly IAnimalService _service;
        public AnimalController(IAnimalService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Animal>> GetAll()
        {
            List<Animal> animals = _service.GetAnimals();

            if (!animals.Any())
            {
                return NotFound("Nie znaleziono żadnego zwierzęcia w bazie danych");
            }

            return Ok(animals);
        }
    }
}
