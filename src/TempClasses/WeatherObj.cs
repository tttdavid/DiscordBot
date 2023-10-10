using System;

namespace src.TempClasses
{
    public class WeatherObj
    {
        public double Temp { get; set; }
        public double Feels { get; set; }
        public string Status { get; set; }
        public string Icon { get; set; }

        public WeatherObj(double temp, double feels, string status, string icon)
        {
            Temp = temp;
            Feels = feels;
            Status = status;
            Icon = icon;
        }
    }
}
