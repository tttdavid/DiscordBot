using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace src.FinancialClasses
{
    public class CurrencyRate
    {
        [JsonProperty("currency_name")]
        public string CurrencyName { get; set; }

        [JsonProperty("rate")]
        public string Rate { get; set; }

        [JsonProperty("rate_for_amount")]
        public string RateForAmount { get; set; }
    }
}
