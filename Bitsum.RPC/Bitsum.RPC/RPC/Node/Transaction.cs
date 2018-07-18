
namespace Bitsum.RPC.Node
{
    using Newtonsoft.Json;

    public class Transaction : TransactionPreview
    {
        [JsonProperty("block")]
        public BlockPreview FromBlock { get; set; }

        [JsonProperty("extra")]
        public string Extra { get; set; }

        [JsonProperty("unlock_time")]
        public ulong UnlockTime { get; set; }

        [JsonProperty("version")]
        public byte Version { get; set; }
    }
}
