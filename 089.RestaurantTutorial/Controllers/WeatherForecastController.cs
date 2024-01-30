using _089.RestaurantTutorial.Models;
using _089.RestaurantTutorial.Service;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace _089.RestaurantTutorial.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpPost("generate")]
        public ActionResult<IEnumerable<WeatherForecast>> Generate([FromQuery] int count, [FromBody] TemperatureDto request)
        {
            if (count < 0 || request.Min > request.Max)
            {
                return BadRequest();
            }
            var result = _service.GetForecast(count, request.Min, request.Max);
            return Ok(result);
        }
    }
}