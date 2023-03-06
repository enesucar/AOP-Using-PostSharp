using Microsoft.AspNetCore.Mvc;
using WebAPI.Aspects;
using WebAPI.DataAccess;
using WebAPI.Validators;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [UnhandledExceptionAspect]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastController(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        } 

        [HttpGet]
        [PerformanceAspect]
        [LoggingAspect]
        [CachingAspect("GetList.WeatherForecast")]
        //[TransactionAspect]
        public async Task<IList<WeatherForecast>> GetList()
        {
            var result = _weatherForecastRepository.GetList();
            return await Task.FromResult(result);
        }

        [HttpPost]
        [ValidationAspect(typeof(WeatherForecastValidator))]
        [CacheRemoveAspect("GetList.WeatherForecast")]
        public async Task<WeatherForecast> Create(WeatherForecast weatherForecast)
        {
            _weatherForecastRepository.Create(weatherForecast);
            return await Task.FromResult(weatherForecast);
        }
    }
}