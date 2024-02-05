using _088._AutoMapper.Models;
using _088._AutoMapper.Service;
using AutoMapper;
using AutoMapper.Database.Entities;
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
                var userDto = _mapper.Map<UserDto>(user);
                return Ok(userDto);
            }
            catch
            {
                return StatusCode(500, "Wystąpił błąd serwera!");
            }
        }
        [HttpPost]
        public ActionResult CreateUser([FromBody] UserDto userDto)
        {
            try
            {
            if(userDto == null)
            {
                return BadRequest("Proszę wpisać poprawne dane");
            }
            UserDto? user = _service.CreateUser(userDto);

            return Ok("Użytkownik utworzony pomyślnie");
            }
            catch 
            {
                return StatusCode(500, "Wystąpił błąd serwera!");
            }
        }
    }
}
