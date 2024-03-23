using api.Entities;
using api.Models;
using api.Services;
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
        [HttpGet]
        public ActionResult<List<UserDto>> GetAll()
        {
            var users = _service.GetAll();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _service.GetUser(id);
            return Ok(user);
        }
    }
}
