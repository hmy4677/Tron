using Furion.DependencyInjection;
using Interface.Common;
using Model.Common;

namespace Service.Common
{
    public class WeatherService : IWeatherService, ITransient
    {
        private static readonly string[] _summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherService()
        {
        }

        public IEnumerable<WeatherForecast> GetWeatherData()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = _summaries[Random.Shared.Next(_summaries.Length)]
            })
            .ToArray();
        }
    }
}