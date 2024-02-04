using _088._AutoMapper.Service;
using AutoMapper.Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _088._AutoMapper.Controllers
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
        public IEnumerable<User> GetUsers()
        {
            var users = _service.GetUsers();
            return users;
        }
    }
}
