
namespace Bitsum.RPC.Node
{
    using Newtonsoft.Json;

    public class BlockPreview
    {
        [JsonProperty("difficulty")]
        public ulong Difficulty { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("height")]
        public uint Height { get; set; }

        [JsonProperty("size")]
        public uint Size { get; set; }

        [JsonProperty("timestamp")]
        public uint Timestamp { get; set; }

        [JsonProperty("tx_count")]
        public long TransactionsCount { get; set; }
    }
}
