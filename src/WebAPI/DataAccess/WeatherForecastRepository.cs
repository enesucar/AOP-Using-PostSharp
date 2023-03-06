namespace WebAPI.DataAccess
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", " ", "Sweltering", "Scorching"
        };

        private IList<WeatherForecast> _weatherForecasts;

        public WeatherForecastRepository()
        {
            _weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
        }

        public void Create(WeatherForecast weatherForecast)
        {
            _weatherForecasts.Add(weatherForecast);
        }

        public IList<WeatherForecast> GetList()
        {
            return _weatherForecasts;
        }
    }
}
