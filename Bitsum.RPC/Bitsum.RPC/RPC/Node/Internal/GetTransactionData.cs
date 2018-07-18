
namespace Bitsum.RPC.Node
{
    using Newtonsoft.Json;

    class GetTransactionData
    {
        public class TransactionEx
        {
            [JsonProperty("extra")]
            public string Extra { get; set; }

            [JsonProperty("unlock_time")]
            public ulong UnlockTime { get; set; }

            [JsonProperty("version")]
            public byte Version { get; set; }
        }

        public class Request
        {
            [JsonProperty("hash")]
            public string Hash { get; set; }
        }

        public class Response
        {
            [JsonProperty("block")]
            public BlockPreview Block { get; set; }

            [JsonProperty("transaction")]
            public TransactionEx Transaction { get; set; }

            [JsonProperty("transaction_details")]
            public TransactionPreview TransactionDetails { get; set; }
        }
    }
}
