using _089.RestaurantTutorial.Entities;
using _089.RestaurantTutorial.Models;
using _089.RestaurantTutorial.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace _089.RestaurantTutorial.Controllers
{
    [Route("api/restaurant/{restaurantId}/dish")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _service;
        public DishController(IDishService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Dish>> GetAll([FromRoute] int restaurantId)
        {
            var dishes = _service.GetAllDishes(restaurantId);
            return Ok(dishes);
        }

        [HttpGet("{dishId}")]
        public ActionResult<Dish> GetDish([FromRoute] int restaurantId, [FromQuery] int dishId)
        {
            Dish dish = _service.GetDish(restaurantId, dishId);
            return Ok(dish);
        }
        [HttpPost]
        public ActionResult CreateDish([FromRoute] int restaurantId, [FromBody] CreateDishDto dishDto)
        {
            _service.CreateDish(restaurantId, dishDto);

            return Created($"api/restaurant/{restaurantId}/dish", null);
        }
    }
}
