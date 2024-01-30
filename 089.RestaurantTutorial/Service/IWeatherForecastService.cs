using _089.RestaurantTutorial.Models;

namespace _089.RestaurantTutorial.Service
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> GetForecast(int count, int minTemperature, int maxTemperature);
    }

    public class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public IEnumerable<WeatherForecast> GetForecast(int count, int minTemperature, int maxTemperature)
        {
            var forecast = Enumerable.Range(1, count).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(minTemperature, maxTemperature),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
            return forecast;

        }
    }
}
