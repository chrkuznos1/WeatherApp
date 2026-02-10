namespace WeatherApp.Models
{
    public class WeatherForecast
    {
        public string? City { get; set; }
        public string? Country { get; set; }
        public List<ForecastItem>? Forecasts { get; set; }
    }
}
