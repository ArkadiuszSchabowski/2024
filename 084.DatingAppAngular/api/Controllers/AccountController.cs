using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
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
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _service.RegisterUser(dto);
            return Ok("Zarejestrowano pomyślnie");
        }
        //[HttpPost("login")]
        //public ActionResult<string> Login(LoginDto dto)
        //{
        //    string token = _service.Login(dto);

        //    return Ok(token);
        //}

    }
}
