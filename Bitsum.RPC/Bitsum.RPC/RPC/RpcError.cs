
namespace Bitsum.RPC
{
    using Newtonsoft.Json;

    public class RpcError
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
