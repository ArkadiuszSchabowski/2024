using _088._AutoMapper.Models;
using _088._AutoMapper.Service;
using AutoMapper;
using AutoMapper.Database.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace _088._AutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            try
            {
                var users = _service.GetUsers();

                if (!users.Any())
                {
                    return NotFound("Brak użytkowników w bazie danych!");
                }
                var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

                return Ok(usersDto);
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
                UserDto userDto = _service.MapUserToDto(user);
                return Ok(userDto);
            }
            catch
            {
                return StatusCode(500, "Wystąpił błąd serwera!");
            }
        }
        [HttpPost]
        public ActionResult CreateUser([FromBody] CreateUserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                User user = _service.CreateUser(userDto);

                return Created($"api/User/{user.Id}", null);
            }
            catch
            {
                return StatusCode(500, "Wystąpił błąd serwera");
            }
        }
        [HttpDelete("{id}")]
        public ActionResult RemoveUser([FromRoute] int id)
        {
            User? user = _service.RemoveUser(id);
            if(user == null)
            {
                return NotFound("Nie znaleziono użytkownika o podanym Id");
            }
            return Ok($"Użytkownik o id: {id} pomyślnie usunięty");
        }
        [HttpPut("{id}")]
        public ActionResult UpdateUser([FromRoute] int id, [FromBody] UpdateUserDto dto)
        {
            var user = _service.UpdateUser(id, dto);
            if(user == null)
            {
                return NotFound("Nie znaleziono użytkownika o podanym Id");
            }
            return Ok("Dane użytkownika pomyślnie zmodyfikowane");
        }
    }
}

