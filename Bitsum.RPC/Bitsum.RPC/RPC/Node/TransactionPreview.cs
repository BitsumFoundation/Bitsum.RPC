
namespace Bitsum.RPC.Node
{
    using Newtonsoft.Json;

    public class TransactionPreview
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("amount_in")]
        public ulong AmountIn { get; set; }

        [JsonProperty("amount_out")]
        public ulong AmountOut { get; set; }

        [JsonProperty("size")]
        public ulong Size { get; set; }

        [JsonProperty("mixin")]
        public uint Mixin { get; set; }

        [JsonProperty("payment_id")]
        public string PaymentId { get; set; }
    }
}
