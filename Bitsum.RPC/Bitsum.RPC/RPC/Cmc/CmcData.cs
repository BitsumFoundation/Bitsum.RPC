using System;
using System.Collections.Generic;
using System.Text;

namespace Bitsum.RPC.Cmc
{
    using Newtonsoft.Json;

    public class CmcData
    {
        public class QuotesData
        {
            public class Values
            {
                [JsonProperty("price")]
                public decimal Price { get; set; }

                [JsonProperty("volume_24h")] 
                public decimal Volume { get; set; }

                [JsonProperty("market_cap")]
                public decimal MarketCap { get; set; }

            }

            [JsonProperty("USD")]
            public Values USD { get; set; }

            [JsonProperty("BTC")]
            public Values BTC { get; set; }
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("quotes")]
        public QuotesData Quotes { get; set; }
    }
}
