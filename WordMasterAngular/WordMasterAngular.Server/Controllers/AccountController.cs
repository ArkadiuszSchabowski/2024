using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordMaster.Server.Models;
using WordMaster.Server.Services;

namespace WordMaster.Server.Controllers
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
        public ActionResult CreateAccount([FromBody] CreateUserDto dto)
        {
            _service.CreateAccount(dto);
            return Ok();
        }
        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] LoginDto dto)
        {
            string token = _service.Login(dto);
            return Ok(token);
        }
    }
}
