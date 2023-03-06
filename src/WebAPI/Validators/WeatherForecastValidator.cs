using FluentValidation;

namespace WebAPI.Validators
{
    public class WeatherForecastValidator : AbstractValidator<WeatherForecast>
    {
        public WeatherForecastValidator()
        {
            RuleFor(o => o.Date).LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now));
        }
    }
}
