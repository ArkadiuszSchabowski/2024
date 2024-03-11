using api.Entities;
using api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        public ActionResult<List<AppUser>> GetAll()
        {
            var users = _service.GetAll();
            return Ok(users);
        }
        public ActionResult<AppUser> GetUser(int id)
        {
            var user = _service.GetUser(id);
            return Ok(user);
        }
    }
}
