namespace WeatherApp.Models
{
    public class OpenWeatherMapForecastResponse
    {
        public List<ForecastData>? list { get; set; }
        public City? city { get; set; }
    }
}
