namespace WeatherApp.Models
{
    public class ForecastItem
    {
        public DateTime DateTime { get; set; }
        public double Temperature { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public string? Description { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public string? Icon { get; set; }
    }
}
