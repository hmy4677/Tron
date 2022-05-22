using Model.Common;

namespace Interface.Common
{
    public interface IWeatherService
    {
        public IEnumerable<WeatherForecast> GetWeatherData();
    }
}