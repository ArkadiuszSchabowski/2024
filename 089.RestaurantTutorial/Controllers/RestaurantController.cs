using _089.RestaurantTutorial.Entities;
using _089.RestaurantTutorial.Models;
using _089.RestaurantTutorial.Service;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public RestaurantController(IRestaurantService service, MyDbContext context, IMapper mapper)
        {
            _service = service;
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> GetAll()
        {
            var restaurants = _service.GetAll();
            var dtoRestaurants = _mapper.Map<List<RestaurantDto>>(restaurants);

            return Ok(dtoRestaurants);
        }
        [HttpGet("{id}")]
        public ActionResult<Restaurant> Get([FromRoute] int id)
        {
            var restaurant = _context.Restaurants.Find(id);
            if(restaurant == null)
            {
                return NotFound("Nie znaleziono restauracji o podanym Id");
            }
            var Dtorestaurant = _mapper.Map<RestaurantDto>(restaurant);
            return Ok(Dtorestaurant);
        }
    }
}
