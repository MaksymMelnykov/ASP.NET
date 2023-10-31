namespace Lab9.Models
{
    public class Weather
    {
        public Main Main { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public Sys Sys { get; set; }
        public Wind Wind {get; set;}
    }

    public class Main
    {
        public float Temp { get; set; }
        public float Feels_like { get; set; }
        public float Pressure { get; set; }
        public float Humidity { get; set; }
    }

    public class Sys
    {
        public int Type { get; set; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
    }
}
