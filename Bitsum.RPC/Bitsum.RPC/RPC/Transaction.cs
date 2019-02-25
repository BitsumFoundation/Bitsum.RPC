
namespace Bitsum.RPC
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    public class Transaction
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("block_hash")]
        public string BlockHash { get; set; }

        [JsonProperty("fee")]
        public ulong Fee { get; set; }

        [JsonProperty("payment_id")]
        public string PaymentId { get; set; }

        [JsonProperty("transfers")]
        public List<Transfer> Transfers { get; set; }

        [JsonProperty("unlock_time")]
        public uint UnlockTime { get; set; }

        [JsonIgnore]
        public string TransactionHex { get; set; }

        [JsonIgnore]
        public int Length { get => (TransactionHex == null) ? 0 : TransactionHex.Length / 2; }
    }
}
