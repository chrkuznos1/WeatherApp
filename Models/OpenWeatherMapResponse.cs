namespace WeatherApp.Models
{
    // OpenWeatherMap API response models
    public class OpenWeatherMapResponse
    {
        public Coord? coord { get; set; }
        public List<Weather>? weather { get; set; }
        public Main? main { get; set; }
        public Wind? wind { get; set; }
        public Sys? sys { get; set; }
        public string? name { get; set; }
        public long dt { get; set; }
    }
}
