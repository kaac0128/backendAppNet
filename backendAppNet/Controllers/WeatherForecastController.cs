using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backendAppNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogTrace($"{nameof(WeatherForecastController)} - {nameof(Get)} - Trace log level");
            _logger.LogDebug($"{nameof(WeatherForecastController)} - {nameof(Get)} - Debug log level");
            _logger.LogInformation($"{nameof(WeatherForecastController)} - {nameof(Get)} - Info log level");
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(Get)} - Warning log level");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(Get)} - Error log level");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(Get)} - Critical log level");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}