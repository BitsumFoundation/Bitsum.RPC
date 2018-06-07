
namespace Bitsum.RPC
{
    using Newtonsoft.Json;

    public class RpcResponse<T>
    {
        [JsonProperty(PropertyName = "error", Required = Required.Default)]
        public RpcError Error { get; set; }

        [JsonProperty(PropertyName = "result", Required = Required.Default)]
        public T Result { get; set; }

        [JsonIgnore]
        public string JsonData { get => JsonConvert.SerializeObject(this, Formatting.Indented); }
    }
}
