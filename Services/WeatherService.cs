using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        Task<WeatherResponse?> GetCurrentWeatherAsync(string city);
        Task<WeatherForecast?> GetForecastAsync(string city, int days = 5);
    }

    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5";

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiKey = _configuration["OpenWeatherMap:ApiKey"] ?? "demo"; // Use demo for testing
        }

        public async Task<WeatherResponse?> GetCurrentWeatherAsync(string city)
        {
            try
            {
                var url = $"{BaseUrl}/weather?q={city}&appid={_apiKey}&units=metric";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();
                var weatherData = JsonConvert.DeserializeObject<OpenWeatherMapResponse>(content);

                if (weatherData == null)
                {
                    return null;
                }

                return new WeatherResponse
                {
                    City = weatherData.name,
                    Country = weatherData.sys?.country,
                    Temperature = Math.Round(weatherData.main?.temp ?? 0, 1),
                    FeelsLike = Math.Round(weatherData.main?.feels_like ?? 0, 1),
                    Description = weatherData.weather?.FirstOrDefault()?.description,
                    Humidity = weatherData.main?.humidity ?? 0,
                    WindSpeed = Math.Round(weatherData.wind?.speed ?? 0, 1),
                    Icon = weatherData.weather?.FirstOrDefault()?.icon,
                    DateTime = DateTimeOffset.FromUnixTimeSeconds(weatherData.dt).DateTime
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching weather: {ex.Message}");
                return null;
            }
        }

        public async Task<WeatherForecast?> GetForecastAsync(string city, int days = 5)
        {
            try
            {
                var url = $"{BaseUrl}/forecast?q={city}&appid={_apiKey}&units=metric&cnt={days * 8}";
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();
                var forecastData = JsonConvert.DeserializeObject<OpenWeatherMapForecastResponse>(content);

                if (forecastData == null || forecastData.list == null)
                {
                    return null;
                }

                var forecasts = forecastData.list.Select(item => new ForecastItem
                {
                    DateTime = DateTimeOffset.FromUnixTimeSeconds(item.dt).DateTime,
                    Temperature = Math.Round(item.main?.temp ?? 0, 1),
                    TempMin = Math.Round(item.main?.temp_min ?? 0, 1),
                    TempMax = Math.Round(item.main?.temp_max ?? 0, 1),
                    Description = item.weather?.FirstOrDefault()?.description,
                    Humidity = item.main?.humidity ?? 0,
                    WindSpeed = Math.Round(item.wind?.speed ?? 0, 1),
                    Icon = item.weather?.FirstOrDefault()?.icon
                }).ToList();

                return new WeatherForecast
                {
                    City = forecastData.city?.name,
                    Country = forecastData.city?.country,
                    Forecasts = forecasts
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching forecast: {ex.Message}");
                return null;
            }
        }
    }
}
