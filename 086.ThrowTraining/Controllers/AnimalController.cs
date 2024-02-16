using _086.ThrowTraining.Exceptions;
using _086.ThrowTraining.Service;
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

            return Ok(animals);
        }
    }
}
