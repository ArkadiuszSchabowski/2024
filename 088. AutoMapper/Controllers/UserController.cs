using _088._AutoMapper.Service;
using AutoMapper.Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

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
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            try
            {
                var users = _service.GetUsers();

                if (users.Any())
                {
                    return NotFound("Brak użytkowników w bazie danych!");
                }

                return Ok(users);
            }
            catch
            {
                return StatusCode(500, "Wystąpił błąd serwera!");
            }
        }
        [HttpGet("{id}")]
        public ActionResult<User> GetUser([FromRoute] int id)
        {
            try
            {
                var user = _service.GetUser(id);
                if (user == null)
                {
                    return NotFound("Nie znaleziono użytkownika o podanym Id!");
                }
                return Ok(user);
            }
            catch
            {
                return StatusCode(500, "Wystąpił błąd serwera!");
            }
        }
    }
}
