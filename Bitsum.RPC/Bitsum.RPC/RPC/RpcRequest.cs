
namespace Bitsum.RPC
{
    using Newtonsoft.Json;

    public class RpcRequest<T>
    {
        [JsonProperty("jsonrpc")]
        public string Version => "2.0";

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public T Arguments { get; set; }
    }
}
