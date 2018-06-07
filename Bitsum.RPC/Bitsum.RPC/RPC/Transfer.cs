
namespace Bitsum.RPC
{
    using Newtonsoft.Json;

    public class Transfer
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
