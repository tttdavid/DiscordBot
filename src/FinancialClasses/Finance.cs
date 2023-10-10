using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace src.FinancialClasses
{
    public class Finance
    {
        static string key = Pepsi.Get("currency");
        public static async Task<decimal> Exchange(string amount, string from, string target)
        {
            using (var httpClient = new HttpClient())
            {
                string apiUrl = $"https://api.getgeoapi.com/v2/currency/convert?api_key={key}&from={from}&to={target}&amount={amount}";
                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();
                    CurrencyData data = JsonConvert.DeserializeObject<CurrencyData>(jsonData);

                    return Convert.ToDecimal(data.Rates[$"{target}"].RateForAmount);
                }
                else
                {
                    return 0.00M;

                }
            }
        }
    }
}
