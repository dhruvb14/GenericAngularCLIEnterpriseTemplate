using Reinforced.Typings.Attributes;

namespace Models
{
    [TsInterface(AutoI=false)]
    public class WeatherForecastViewModel
    {
        public string DateFormatted { get; set; }   
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
        public string Summary { get; set; }
    }
}