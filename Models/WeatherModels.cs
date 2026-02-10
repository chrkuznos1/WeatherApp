namespace WeatherApp.Models
{
    public class WeatherResponse
    {
        public string? City { get; set; }
        public string? Country { get; set; }
        public double Temperature { get; set; }
        public double FeelsLike { get; set; }
        public string? Description { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public string? Icon { get; set; }
        public DateTime DateTime { get; set; }
        //public string ErrorMessage { get; set; }
    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Weather
    {
        public string? main { get; set; }
        public string? description { get; set; }
        public string? icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int humidity { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
    }

    public class Sys
    {
        public string? country { get; set; }
    }

    public class City
    {
        public string? name { get; set; }
        public string? country { get; set; }
    }
}
