using _089.RestaurantTutorial.Entities;
using _089.RestaurantTutorial.Models;
using _089.RestaurantTutorial.Service;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            RestaurantDto restaurant = _service.GetRestaurant(id);

            return Ok(restaurant);
        }
        [HttpPost]
        public ActionResult CreateRestaurant([FromBody] RestaurantDto restaurantDto)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantDto);

            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();

            return Ok(restaurant);
        }

    }
}
