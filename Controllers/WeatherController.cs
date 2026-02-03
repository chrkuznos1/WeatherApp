using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(IWeatherService weatherService, ILogger<WeatherController> logger)
        {
            _weatherService = weatherService;
            _logger = logger;
        }

        /// <summary>
        /// Get current weather for a city
        /// </summary>
        /// <param name="city">City name (e.g., London, Paris, New York)</param>
        /// <returns>Current weather information</returns>
        [HttpGet("current/{city}")]
        [ProducesResponseType(typeof(WeatherResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WeatherResponse>> GetCurrentWeather(string city)
        {
            _logger.LogInformation("Fetching current weather for {City}", city);

            var weather = await _weatherService.GetCurrentWeatherAsync(city);

            if (weather == null)
            {
                _logger.LogWarning("Weather data not found for {City}", city);
                return NotFound(new { message = $"Weather data not found for city: {city}" });
            }

            return Ok(weather);
        }

        /// <summary>
        /// Get weather forecast for a city
        /// </summary>
        /// <param name="city">City name (e.g., London, Paris, New York)</param>
        /// <param name="days">Number of days (default: 5)</param>
        /// <returns>Weather forecast information</returns>
        [HttpGet("forecast/{city}")]
        [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WeatherForecast>> GetForecast(string city, [FromQuery] int days = 5)
        {
            _logger.LogInformation("Fetching {Days} day forecast for {City}", days, city);

            if (days < 1 || days > 5)
            {
                return BadRequest(new { message = "Days parameter must be between 1 and 5" });
            }

            var forecast = await _weatherService.GetForecastAsync(city, days);

            if (forecast == null)
            {
                _logger.LogWarning("Forecast data not found for {City}", city);
                return NotFound(new { message = $"Forecast data not found for city: {city}" });
            }

            return Ok(forecast);
        }

        /// <summary>
        /// Health check endpoint
        /// </summary>
        [HttpGet("health")]
        public IActionResult HealthCheck()
        {
            return Ok(new
            {
                status = "healthy",
                timestamp = DateTime.UtcNow,
                service = "Weather API."
            });
        }
    }
}
