namespace WebAPI.DataAccess
{
    public interface IWeatherForecastRepository
    {
        IList<WeatherForecast> GetList();
        void Create(WeatherForecast weatherForecast);
    }
}
