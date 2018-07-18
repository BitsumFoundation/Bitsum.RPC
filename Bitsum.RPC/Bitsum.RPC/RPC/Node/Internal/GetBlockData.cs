
namespace Bitsum.RPC.Node
{
    using Newtonsoft.Json;

    internal class GetBlockData
    {
        public class Request
        {
            [JsonProperty("height")]
            public ulong Height { get; set; } = ulong.MaxValue;

            [JsonProperty("hash")]
            public string Hash { get; set; } = string.Empty;
        }

        public class Response
        {
            [JsonProperty("block")]
            public Block Block { get; set; }
        }
    }
}
