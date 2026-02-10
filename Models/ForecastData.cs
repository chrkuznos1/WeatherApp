namespace WeatherApp.Models
{
    public class ForecastData
    {
        public long dt { get; set; }
        public Main? main { get; set; }
        public List<Weather>? weather { get; set; }
        public Wind? wind { get; set; }
    }
}
