
namespace Bitsum.RPC
{
    using Newtonsoft.Json;

    public class PoolStats
    {
        //[JsonProperty("lastShare")]
        //private ulong lastShare;

        [JsonProperty("balance")]
        public decimal PendingBalance { get; set; }

        [JsonProperty("paid")]
        public decimal TotalPaid { get; set; }

        [JsonProperty("hashrate")]
        public string Hashrate { get; set; }

        [JsonProperty("hashes")]
        public ulong TotalHashesSubmitted { get; set; }

        //[JsonIgnore]
        //public DateTime LastHashSubmitted { get { return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1).AddSeconds(lastShare)); } }
    }
}
