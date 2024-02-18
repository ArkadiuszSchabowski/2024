using _089.RestaurantTutorial.Models;
using _089.RestaurantTutorial.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _089.RestaurantTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public ActionResult CreateUser(RegisterUserDto dto)
        {
            var newUser = _service.CreateUser(dto);
            return Ok();

        }
    }
}
