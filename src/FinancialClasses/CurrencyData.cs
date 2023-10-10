using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace src.FinancialClasses
{
    public class CurrencyData
    {
        [JsonProperty("base_currency_code")]
        public string BaseCurrencyCode { get; set; }

        [JsonProperty("base_currency_name")]
        public string BaseCurrencyName { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("updated_date")]
        public DateTime UpdatedDate { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, CurrencyRate> Rates { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
