using Newtonsoft.Json;

namespace Bitsum.RPC.Wallet
{
    internal class KeysData
    {
        public class Request
        {
            [JsonProperty("address")]
            public string Address { get; set; }
        }

        public class Response
        {
            [JsonProperty("keys")]
            public string Keys { get; set; }
        }
    }
}
