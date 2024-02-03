using _089.RestaurantTutorial.Entities;
using _089.RestaurantTutorial.Models;
using _089.RestaurantTutorial.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _089.RestaurantTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {

        private readonly IRestaurantService _service;
        private readonly MyDbContext _context;

        public RestaurantController(IRestaurantService service, MyDbContext context)
        {
            _service = service;
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> GetAll()
        {
            var restaurant = _service.GetAll();
            //TODO
            var dtoRestaurant = restaurant;

            return Ok(restaurant);
        }
        [HttpGet("{id}")]
        public ActionResult<Restaurant> Get([FromRoute] int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            if(restaurant == null)
            {
                return NotFound("Nie znaleziono restauracji o podanym Id");
            }
            return Ok(restaurant);
        }
    }
}
