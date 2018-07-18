
namespace Bitsum.RPC.Node
{
    using Newtonsoft.Json;

    public class BlockHeader
    {
        [JsonProperty("major_version")]
        public byte MajorVersion { get; set; }

        [JsonProperty("minor_version")]
        public byte MinorVersion { get; set; }

        [JsonProperty("timestamp")]
        public uint Timestamp { get; set; }

        [JsonProperty("previous_block_hash")]
        public string PreviousBlockHash { get; set; }

        [JsonProperty("nonce")]
        public uint Nonce { get; set; }

        [JsonProperty("height")]
        public uint Height { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("reward")]
        public ulong Reward { get; set; }

        [JsonProperty("cumulative_difficulty")]
        public ulong CumulativeDifficulty { get; set; }

        [JsonProperty("difficulty")]
        public ulong Difficulty { get; set; }

        [JsonProperty("base_reward")]
        public ulong BaseReward { get; set; }

        [JsonProperty("block_size")]
        public uint BlockSize { get; set; }

        [JsonProperty("transactions_cumulative_size")]
        public uint TransactionsCumulativeSize { get; set; }

        [JsonProperty("already_generated_coins")]
        public ulong AlreadyGeneratedCoins { get; set; }

        [JsonProperty("already_generated_transactions")]
        public ulong AlreadyGeneratedTransactions { get; set; }

        [JsonProperty("size_median")]
        public uint SizeMedian { get; set; }

        [JsonProperty("effective_size_median")]
        public uint EffectiveSizeMedian { get; set; }

        [JsonProperty("timestamp_median")]
        public uint TimestampMedian { get; set; }

        [JsonProperty("timestamp_unlock")]
        public uint TimestampUnlock { get; set; }

        [JsonProperty("total_fee_amount")]
        public ulong TotalFeeAmount { get; set; }

        [JsonProperty("penalty")]
        public double Penalty { get; set; }

        [JsonProperty("orphan_status")]
        public bool OrphanStatus { get; set; }

        [JsonProperty("depth")]
        public uint Depth { get; set; }
    }
}
