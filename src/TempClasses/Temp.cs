using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace src.TempClasses
{
    public static class Temp
    {
        static string key = Pepsi.Get("weather");
        public static async Task<WeatherObj> Weather(string city)
        {
            using (var httpClient = new HttpClient())
            {
                string apiUrl = $"https://api.weatherapi.com/v1/forecast.json?key={key}&q={city}";
                var response = await httpClient.GetAsync(apiUrl);

                string jsonData = await response.Content.ReadAsStringAsync();
                Root weatherData = JsonConvert.DeserializeObject<Root>(jsonData);

                WeatherObj obj = new(weatherData.current.temp_c, weatherData.current.feelslike_c, weatherData.current.condition.text, weatherData.current.condition.icon);

                return obj;
            }
        }

        public static async Task<DateTime> Time(string city)
        {
            using (var httpClient = new HttpClient())
            {
                string apiUrl = $"https://api.weatherapi.com/v1/forecast.json?key={key}&q={city}";
                var response = await httpClient.GetAsync(apiUrl);
                string jsonData = await response.Content.ReadAsStringAsync();

                JObject weatherData = JObject.Parse(jsonData);

                string localTimeStr = weatherData["location"]["localtime"].ToString();
                DateTime localTime = DateTime.Parse(localTimeStr);

                return localTime;
            }
        }
    }
}
