using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _092.HairDressingSalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        [HttpGet("freedates")]
        public ActionResult GetFreeDates()
        {
            //All
        }
        [HttpGet("ownbooking")]
        public ActionResult ShowOwnBooking()
        {
            //User
        }
        [HttpGet("allbooking")]
        public ActionResult ShowAllBooking()
        {
            //Manager
        }
        [HttpPost("addbooking")]
        public ActionResult AddBooking([FromBody] DateTime date)
        {
            //User
        }
        [HttpDelete("removebooking")]
        public ActionResult DeleteOwnBooking([FromBody] DateTime date)
        {
            //User
        }
        [HttpDelete("removebookinguser/{id}")]
        public ActionResult DeleteUserBooking([FromRoute] int id)
        {
            //Manager
        }
    }
}
