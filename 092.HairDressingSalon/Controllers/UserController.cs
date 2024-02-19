using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _092.HairDressingSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("login")]
        public ActionResult RegisterUser()
        {
            //All
            _service.RegisterUser();
            return Ok();
        }
        [HttpPost("registration")]
        public ActionResult LoginUser()
        {
            //All
            _service.LoginUser();
            return Ok();
        }
    }
}
